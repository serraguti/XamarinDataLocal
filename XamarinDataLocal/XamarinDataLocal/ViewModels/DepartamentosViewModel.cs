using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinDataLocal.Base;
using XamarinDataLocal.Models;
using XamarinDataLocal.Repositories;

namespace XamarinDataLocal.ViewModels
{
    public class DepartamentosViewModel: ViewModelBase
    {
        private RepositoryDepartamentos repo;

        public DepartamentosViewModel()
        {
            this.repo = new RepositoryDepartamentos();
            List<Departamento> depts =
                this.repo.GetDepartamentos();
            this.Departamentos = new ObservableCollection<Departamento>(depts);
        }

        private ObservableCollection<Departamento> _Departamentos;

        public ObservableCollection<Departamento> Departamentos
        {
            get { return this._Departamentos; }
            set {
                this._Departamentos = value;
                OnPropertyChanged("Departamentos");
            }
        }
    }
}
