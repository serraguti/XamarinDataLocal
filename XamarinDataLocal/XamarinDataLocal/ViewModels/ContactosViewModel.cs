using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamarinDataLocal.Base;
using XamarinDataLocal.Dependencies;
using XamarinDataLocal.Models;

namespace XamarinDataLocal.ViewModels
{
    public class ContactosViewModel: ViewModelBase
    {
        private ObservableCollection<Contacto> _Contactos;

        public ObservableCollection<Contacto> Contactos
        {
            get { return this._Contactos; }
            set {
                this._Contactos = value;
                OnPropertyChanged("Contactos");
            }
        }

        public Command MostrarContactos
        {
            get
            {
                return new Command(async () =>
                {
                    List<Contacto> contactos =
                    await
                    DependencyService.Get<IContactos>().GetContactosAsync();
                    this.Contactos =
                    new ObservableCollection<Contacto>(contactos);
                });
            }
        }
    }
}
