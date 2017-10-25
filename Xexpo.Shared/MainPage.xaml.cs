using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xexpo.Services;
using Xexpo.Utils;

namespace Xexpo
{
    /// <summary>
    /// Main page.
    /// </summary>
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Xexpo.MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            //XAMLBox.Text = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>\r\n<ContentView xmlns = \"http://xamarin.com/schemas/2014/forms\" xmlns:x = \"http://schemas.microsoft.com/winfx/2009/xaml\" >\r\n\t<ContentView.Content>\r\n\t\t<StackLayout VerticalOptions=\"Center\" HorizontalOptions=\"Center\" BackgroundColor=\"LightBlue\">\r\n\t\t\t<Label Text=\"Hello Xamarin.Forms!\" />\r\n\t\t</StackLayout>\r\n\t</ContentView.Content>\r\n</ContentView>";
            RenderButton.Clicked += RenderButton_Clicked;
        }

        /// <summary>
        /// Renders the button clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private async void RenderButton_Clicked(object sender, EventArgs e)
        {
            // XAML example
            var xaml = await RestService.Current.GetXamlAsync("https://gist.githubusercontent.com/flusharcade/e1822c058c331c847a74bdf464ce766a/raw/a684ded672b6f480b7c43690604a4d8a77ad2fbc/TestView");

            if (!string.IsNullOrEmpty(xaml))
            {
                ContentBox.Content = VerifyXaml(xaml);
            }

            // CSharp example - still working on this.
            //var csharp = await RestService.Current.GetCSharpAsync("https://gist.githubusercontent.com/flusharcade/b3606cdf130df4b33345c03e776516bb/raw/3278bad3f480c8eacb35d26d84f6cc31caae2f7c/EmbeddedView.cs");

            //if (!string.IsNullOrEmpty(csharp))
            //{
            //    ContentBox.Content = VerifyCSharp(csharp);
            //}
        }

        /// <summary>
        /// Checks the xaml errors.
        /// </summary>
        /// <returns><c>true</c>, if xaml errors was checked, <c>false</c> otherwise.</returns>
        /// <param name="xaml">Xaml.</param>
        private View VerifyXaml(string xaml)
        {
            try
            {
                return XamlReader.Load<ContentView>(xaml);
            }
            catch (Exception e)
            {
                var errorView = new ErrorsContentView();
                errorView.Label.Text = e.InnerException?.Message;
                return errorView;
            }
        }

        /// <summary>
        /// Verifies the CS harp.
        /// </summary>
        /// <returns>The CS harp.</returns>
        /// <param name="csharp">Csharp.</param>
        private View VerifyCSharp(string csharp)
        {
            try
            {
                return CSharpReader.Load<ContentView>(csharp);
            }
            catch (Exception e)
            {
                var errorView = new ErrorsContentView();
                errorView.Label.Text = e.InnerException?.Message;
                return errorView;
            }
        }
    }
}
