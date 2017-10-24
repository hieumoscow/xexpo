using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Xexpo
{
    /// <summary>
    /// Errors content view.
    /// </summary>
    public partial class ErrorsContentView : ContentView
    {
        /// <summary>
        /// Gets the error label.
        /// </summary>
        /// <value>The error label.</value>
        public Label Label
        {
            get
            {
                return this.ErrorLabel;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Xexpo.ErrorsContentView"/> class.
        /// </summary>
        public ErrorsContentView()
        {
            InitializeComponent();
        }
    }
}
