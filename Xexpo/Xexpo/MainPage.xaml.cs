using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xexpo.Utils;

namespace Xexpo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            XAMLBox.Text = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>\r\n<ContentView xmlns = \"http://xamarin.com/schemas/2014/forms\" xmlns:x = \"http://schemas.microsoft.com/winfx/2009/xaml\" >\r\n\t<ContentView.Content>\r\n\t\t<StackLayout VerticalOptions=\"Center\" HorizontalOptions=\"Center\" BackgroundColor=\"LightBlue\">\r\n\t\t\t<Label Text=\"Hello Xamarin.Forms!\" />\r\n\t\t</StackLayout>\r\n\t</ContentView.Content>\r\n</ContentView>";
            RenderButton.Clicked += RenderButton_Clicked;
        }


        private void RenderButton_Clicked(object sender, EventArgs e)
        {
            ContentBox.Content = XamlReader.Load<ContentView>(XAMLBox.Text);
        }
    }
}
