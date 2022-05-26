using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinDataLocal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecursoIncrustadoView : ContentPage
    {
        public RecursoIncrustadoView()
        {
            InitializeComponent();
            this.botonLeerFichero.Clicked += BotonLeerFichero_Clicked;
        }

        private void BotonLeerFichero_Clicked(object sender, EventArgs e)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo
                (typeof(RecursoIncrustadoView)).Assembly;
            string namespaces = "XamarinDataLocal.Documents.bash.txt";
            Stream stream = assembly.GetManifestResourceStream(namespaces);
            using (StreamReader reader = new StreamReader(stream))
            {
                String data = reader.ReadToEnd();
                this.labelDatos.Text = data;
            }
        }
    }
}