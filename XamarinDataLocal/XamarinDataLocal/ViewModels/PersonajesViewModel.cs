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
