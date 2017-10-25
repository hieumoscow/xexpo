using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Xexpo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Xexpo.MainPage();
        }

        private void LoadAssets()
        {
            //            var c = LoadAsset<ContractResp>("HomeCreditMock.MockData.ViewContract.json");
            //            var i = LoadAsset<InstalmentsResp>("HomeCreditMock.MockData.ViewInstalments.json");
            //            var p = LoadAsset<PaymentsResp>("HomeCreditMock.MockData.ViewPayments.json");
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
