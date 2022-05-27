using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDataLocal.Models;
using XamarinDataLocal.ViewModels;

namespace XamarinDataLocal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeliculasView : ContentPage
    {
        public PeliculasView()
        {
            InitializeComponent();
        }
    }
}