using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinDataLocal.Base;
using XamarinDataLocal.Models;
using XamarinDataLocal.Repositories;

namespace XamarinDataLocal.ViewModels
{
    public class SeriesViewModel: ViewModelBase
    {
        private RepositorySeries repo;

        public SeriesViewModel()
        {
            this.repo = new RepositorySeries();
            this.Series =
                new ObservableCollection<Serie>(this.repo.GetSeries());
        }

        private ObservableCollection<Serie> _Series;
        public ObservableCollection<Serie> Series
        {
            get { return this._Series; }
            set {
                this._Series = value;
                OnPropertyChanged("Series");
            }
        }
    }
}
