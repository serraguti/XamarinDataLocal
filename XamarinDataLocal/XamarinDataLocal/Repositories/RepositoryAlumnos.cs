using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XamarinDataLocal.Helpers;
using XamarinDataLocal.Models;

namespace XamarinDataLocal.Repositories
{
    public class RepositoryAlumnos
    {
        public List<Alumno> GetAlumnos()
        {
            string data = HelperFiles.ReadFile("alumnos.xml");
            XDocument docxml = XDocument.Parse(data);
            var consulta = from datos in docxml.Descendants("Alumno")
                           select new Alumno
                           {
                               Nombre = datos.Element("Nombre").Value,
                               Apellidos = datos.Element("Apellidos").Value
                           };
            return consulta.ToList();
        }
    }
}
