using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDataLocal.Repositories;

namespace XamarinDataLocal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDepartamentosView : ContentPage
    {
        private RepositoryDepartamentos repo;

        public MainDepartamentosView()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentos();
            this.botonCrear.Clicked += BotonCrear_Clicked;
            this.botonEliminar.Clicked += BotonEliminar_Clicked;
            this.botonInsertar.Clicked += BotonInsertar_Clicked;
            this.botonModificar.Clicked += BotonModificar_Clicked;
            this.botonMostrar.Clicked += BotonMostrar_Clicked;
        }

        private async void BotonMostrar_Clicked(object sender, EventArgs e)
        {
            DepartamentosView view = new DepartamentosView();
            await Navigation.PushModalAsync(view);
        }

        private void BotonModificar_Clicked(object sender, EventArgs e)
        {
            int id = int.Parse(this.cajaId.Text);
            this.repo.ModificarDepartamento(id, this.cajaNombre.Text
                , this.cajaLocalidad.Text);
            this.labelMensaje.Text = "Departamento modificado";
        }

        private void BotonInsertar_Clicked(object sender, EventArgs e)
        {
            this.repo.InsertarDepartamento(this.cajaNombre.Text
                , this.cajaLocalidad.Text);
            this.labelMensaje.Text = "Insertado";
        }

        private void BotonEliminar_Clicked(object sender, EventArgs e)
        {
            int id = int.Parse(this.cajaId.Text);
            this.repo.EliminarDepartamento(id);
            this.labelMensaje.Text = "Eliminado";
        }

        private void BotonCrear_Clicked(object sender, EventArgs e)
        {
            this.repo.CrearBBDD();
            this.labelMensaje.Text = "BBDD creada";
        }
    }
}