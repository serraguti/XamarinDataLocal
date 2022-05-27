using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XamarinDataLocal.Helpers;
using XamarinDataLocal.Models;

namespace XamarinDataLocal.Repositories
{
    public class RepositoryPeliculas
    {
        public List<Pelicula> GetPeliculas()
        {
            string fileName = "escenaspeliculas.xml";
            string data = HelperFiles.ReadFile(fileName);
            XDocument document = XDocument.Parse(data);
            var consulta = from datos in document.Descendants("pelicula")
                           select new Pelicula
                           {
                               Titulo = datos.Element("titulo").Value,
                               TituloOriginal = datos.Element("titulooriginal").Value,
                               Descripcion = datos.Element("descripcion").Value,
                               Poster = datos.Element("poster").Value,
Escenas = new List<Escena>(from datosescena in datos.Descendants("escena")
                           select new Escena { 
                                TituloEscena = datosescena.Element("tituloescena").Value,
                                DescripcionEscena = datosescena.Element("descripcion").Value,
                                ImagenEscena = datosescena.Element("imagen").Value
                           })
                           };
            return consulta.ToList();
        }
    }
}
