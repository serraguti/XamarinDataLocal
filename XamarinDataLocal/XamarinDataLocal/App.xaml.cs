using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDataLocal.Services;
using XamarinDataLocal.Views;

namespace XamarinDataLocal
{
    public partial class App : Application
    {
        private static ServiceIoC _ServiceLocator;
        
        public static ServiceIoC ServiceLocator
        {
            get
            {
                //DEVOLVEMOS LA CLASE ServiceIoC
                //SI NO EXISTE, LA CREAMOS...
                return _ServiceLocator = _ServiceLocator ?? new ServiceIoC();
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new PersonajesView();
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
