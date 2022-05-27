using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinDataLocal.Models
{
    public class Pelicula
    {
        public string Titulo { get; set; }
        public string TituloOriginal { get; set; }
        public string Descripcion { get; set; }
        public string Poster { get; set; }
        public List<Escena> Escenas { get; set; }
    }
}
