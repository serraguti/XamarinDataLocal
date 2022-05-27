using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamarinDataLocal.Base;
using XamarinDataLocal.Models;
using XamarinDataLocal.Repositories;
using XamarinDataLocal.Views;

namespace XamarinDataLocal.ViewModels
{
    public class PeliculasViewModel: ViewModelBase
    {
        private RepositoryPeliculas repo;

        public PeliculasViewModel()
        {
            this.repo = new RepositoryPeliculas();
            List<Pelicula> peliculas = repo.GetPeliculas();
            this.Peliculas = new ObservableCollection<Pelicula>(peliculas);
        }

        private ObservableCollection<Pelicula> _Peliculas;

        public ObservableCollection<Pelicula> Peliculas
        {
            get { return this._Peliculas; }
            set { this._Peliculas = value;
                OnPropertyChanged("Peliculas");
            }
        }

        private Pelicula _PeliculaSeleccionada;

        public Pelicula PeliculaSeleccionada
        {
            get { return this._PeliculaSeleccionada; }
            set {
                this._PeliculaSeleccionada = value;
                OnPropertyChanged("PeliculaSeleccionada");
            }
        }

        public Command ShowEscenas
        {
            get
            {
                return new Command(async() =>
                {
                    //CREAMOS EL VIEWMODEL
                    PeliculaViewModel viewmodel = new PeliculaViewModel();
                    //INDICAMOS LA PELICULA A MOSTRAR
                    viewmodel.Pelicula = this.PeliculaSeleccionada;
                    //CREAMOS LA VISTA A MOSTRAR
                    EscenasView view = new EscenasView();
                    //ENLAZAMOS LA VISTA CON SU VIEWMODEL
                    view.BindingContext = viewmodel;
                    //MOSTRAMOS LA VISTA
                    //NAVIGATION SOLAMENTE SE PUEDE UTILIZAR
                    ////DESDE LAS CLASES QUE HEREDEN DE Page
                    //NECESITAMOS ACCEDER A LA APLICACION,
                    ////EL ENTORNO ACTUAL Y LANZAR LA NAVEGACION
                    await 
                    Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}
