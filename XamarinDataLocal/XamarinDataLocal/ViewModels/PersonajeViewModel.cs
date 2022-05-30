using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinDataLocal.Base;
using XamarinDataLocal.Models;
using XamarinDataLocal.Repositories;

namespace XamarinDataLocal.ViewModels
{
    public class PersonajeViewModel: ViewModelBase
    {
        private RepositoryPersonajes repo;

        public PersonajeViewModel()
        {
            this.repo = new RepositoryPersonajes();
            this.Personaje = new Personaje();
        }

        private Personaje _Personaje;

        public Personaje Personaje
        {
            get { return this._Personaje; }
            set {
                this._Personaje = value;
                OnPropertyChanged("Personaje");
            }
        }

        public Command Insertar
        {
            get
            {
                return new Command(() =>
                {
                    this.repo.InsertarPersonaje(this.Personaje.Nombre
                        , this.Personaje.Serie);
                });
            }
        }

        public Command Modificar
        {
            get
            {
                return new Command(() =>
                {
                    this.repo.ModificarPersonaje(this.Personaje.IdPersonaje
                        , this.Personaje.Nombre, this.Personaje.Serie);
                });
            }
        }

        public Command Eliminar
        {
            get
            {
                return new Command(() =>
                {
                    this.repo.EliminarPersonaje(this.Personaje.IdPersonaje);
                });
            }
        }
    }
}
