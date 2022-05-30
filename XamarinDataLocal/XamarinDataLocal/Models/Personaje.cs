using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinDataLocal.Models
{
    public class Personaje: RealmObject
    {
        public int IdPersonaje { get; set; }
        public string Nombre { get; set; }
        public string Serie { get; set; }
    }
}
