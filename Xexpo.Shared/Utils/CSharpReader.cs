using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using xaml = Xamarin.Forms.Xaml;

using System.CodeDom;

using Microsoft.CSharp;
using System.CodeDom.Compiler;

namespace Xexpo.Utils
{
    /// <summary>
    /// Dynamically converts XAML in to UI elements
    /// </summary>
    public static class CSharpReader
    {
        #region Fields
        private static CSharpCodeProvider _Provider;
        private static MethodInfo _CreateMethod;
        #endregion

        #region Static Constructor
        /// <summary>
        /// Initialise this instance.
        /// </summary>
        private static void Initialise()
        {
            _Provider = new CSharpCodeProvider();
        }
        #endregion

        #region Private Static Methods
        /// <summary>
        /// Load the specified view and csharp.
        /// </summary>
        /// <returns>The load.</returns>
        /// <param name="view">View.</param>
        /// <param name="csharp">Csharp.</param>
        /// <typeparam name="TBindableObject">The 1st type parameter.</typeparam>
        private static TBindableObject Load<TBindableObject>(this TBindableObject view, string csharp) where TBindableObject : BindableObject
        {
            try
            {
                if (_CreateMethod == null)
                {
                    Initialise();
                }

                var param = new CompilerParameters
                {
                    GenerateExecutable = false,
                    IncludeDebugInformation = false,
                    GenerateInMemory = true
                };
                param.ReferencedAssemblies.Add("System.dll");
                param.ReferencedAssemblies.Add("System.Xml.dll");
                param.ReferencedAssemblies.Add("System.Data.dll");
                param.ReferencedAssemblies.Add("System.Core.dll");
                param.ReferencedAssemblies.Add("System.Xml.Linq.dll");

                var results = _Provider.CompileAssemblyFromSource(param, csharp);
                var viewGenerator = results.CompiledAssembly.GetType("Xexpo.ViewGenerator");
                _CreateMethod = viewGenerator.GetMethod("Create");

                return (TBindableObject)_CreateMethod.Invoke(null, null);
            }
            catch (Exception ex)
            {
                var anex = ex.InnerException as ArgumentNullException;
                if (anex == null)
                {
                    throw;
                }

                throw;
            }
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Load the specified csharp.
        /// </summary>
        /// <returns>The load.</returns>
        /// <param name="csharp">Csharp.</param>
        /// <typeparam name="TBindableObject">The 1st type parameter.</typeparam>
        public static TBindableObject Load<TBindableObject>(string csharp) where TBindableObject : BindableObject
        {
            if (string.IsNullOrEmpty(csharp))
            {
                throw new ArgumentNullException(nameof(csharp));
            }

            var bindableObject = (TBindableObject)Activator.CreateInstance(typeof(TBindableObject));

            return Load(bindableObject, csharp);
        }

        #endregion
    }
}
