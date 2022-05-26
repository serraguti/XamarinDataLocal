using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinDataLocal.Base;
using XamarinDataLocal.Models;
using XamarinDataLocal.Repositories;

namespace XamarinDataLocal.ViewModels
{
    public class AlumnosViewModel: ViewModelBase
    {
        //NO TENEMOS INYECCION DE DEPENDENCIAS DENTRO DE
        //XAMARIN.  DEBEMOS HACERLO A LA ANTIGUA, POR AHORA...
        private RepositoryAlumnos repo;

        public AlumnosViewModel()
        {
            this.repo = new RepositoryAlumnos();
        }

        private List<Alumno> _Alumnos;

        public List<Alumno> Alumnos
        {
            get { return this._Alumnos; }
            set {
                this._Alumnos = value;
                OnPropertyChanged("Alumnos");
            }
        }

        public Command MostrarAlumnos
        {
            get
            {
                return new Command(() =>
                {
                    this.Alumnos = this.repo.GetAlumnos();
                });
            }
        }
    }
}
