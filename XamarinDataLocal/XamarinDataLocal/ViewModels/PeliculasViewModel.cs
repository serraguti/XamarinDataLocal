using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinDataLocal.Base;
using XamarinDataLocal.Models;
using XamarinDataLocal.Repositories;

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
    }
}
