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
            this.listviewPeliculas.ItemSelected += ListviewPeliculas_ItemSelected;
        }

        private async void ListviewPeliculas_ItemSelected(object sender
            , SelectedItemChangedEventArgs e)
        {
            Pelicula peliculaSeleccionada = e.SelectedItem as Pelicula;
            //CREAMOS EL VIEWMODEL
            PeliculaViewModel viewmodel = new PeliculaViewModel();
            //INDICAMOS AL VIEWMODEL LA PELICULA A MOSTRAR
            viewmodel.Pelicula = peliculaSeleccionada;
            //CREAMOS LA VISTA DE ESCENAS
            EscenasView view = new EscenasView();
            //INDICAMOS EL VIEWMODEL DE LA VISTA
            view.BindingContext = viewmodel;
            await Navigation.PushModalAsync(view);
        }
    }
}