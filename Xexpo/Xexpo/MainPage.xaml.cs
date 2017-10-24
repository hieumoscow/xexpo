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
            var xaml = await RestService.Current.GetXamlAsync("https://gist.githubusercontent.com/flusharcade/9bee4a6402b365fad2cba743536f9bcc/raw/5e7fb180d9ac0b876bfbf0243d386ef02a21e13a/MapView.xaml");

            if (!string.IsNullOrEmpty(xaml))
            {
                ContentBox.Content = VerifyXaml(xaml);
            }
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
    }
}
