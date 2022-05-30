using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDataLocal.Views;

namespace XamarinDataLocal
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ContactosView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
