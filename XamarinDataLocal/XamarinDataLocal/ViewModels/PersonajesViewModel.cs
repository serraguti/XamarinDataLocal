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
    public class PersonajesViewModel: ViewModelBase
    {
        private RepositoryPersonajes repo;
        public PersonajesViewModel()
        {
            this.repo = new RepositoryPersonajes();
            this.Personajes =
                new ObservableCollection<Personaje>(this.repo.GetPersonajes());
        }

        private Personaje _PersonajeSeleccionado;

        public Personaje PersonajeSeleccionado
        {
            get { return this._PersonajeSeleccionado; }
            set {
                this._PersonajeSeleccionado = value;
                OnPropertyChanged("PersonajeSeleccionado");
            }
        }

        private ObservableCollection<Personaje> _Personajes;
        public ObservableCollection<Personaje> Personajes
        {
            get { return this._Personajes; }
            set {
                this._Personajes = value;
                OnPropertyChanged("Personajes");
            }
        }

        public Command Edicion
        {
            get
            {
                return new Command(async () =>
                {
                    PersonajeEdicionView view = new PersonajeEdicionView();
                    PersonajeViewModel viewmodel = new PersonajeViewModel();
                    if (this.PersonajeSeleccionado != null)
                    {
                        viewmodel.Personaje = this.PersonajeSeleccionado;
                    }
                    else
                    {
                        viewmodel.Personaje = new Personaje();
                    }
                    view.BindingContext = viewmodel;
                    await 
                    Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }

        public Command CargarPersonajes
        {
            get
            {
                return new Command( () =>
                {
                    this.Personajes =
                    new ObservableCollection<Personaje>(this.repo.GetPersonajes());
                });
            }
        }
    }
}
