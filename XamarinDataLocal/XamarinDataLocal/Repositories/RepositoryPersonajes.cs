using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinDataLocal.Models;

namespace XamarinDataLocal.Repositories
{
    public class RepositoryPersonajes
    {
        private Realm realmConnection;

        public RepositoryPersonajes()
        {
            this.realmConnection = Realm.GetInstance();
        }

        public List<Personaje> GetPersonajes()
        {
            return this.realmConnection.All<Personaje>().ToList();
        }

        public Personaje FindPersonaje(int id)
        {
            return this.GetPersonajes().SingleOrDefault(z => z.IdPersonaje == id);
        }

        private int GetMaxIdPersonaje()
        {
            if (this.GetPersonajes().Count == 0)
            {
                return 1;
            }
            else
            {
                return this.GetPersonajes().Max(x => x.IdPersonaje) + 1;
            }
        }

        public void InsertarPersonaje(string nombre, string serie)
        {
            using (Transaction transaction = this.realmConnection.BeginWrite())
            {
                Personaje personaje = new Personaje()
                {
                    IdPersonaje = this.GetMaxIdPersonaje(),
                    Nombre = nombre,
                    Serie = serie
                };
                this.realmConnection.Add(personaje);
                transaction.Commit();
            }
        }

        public void ModificarPersonaje(int id, string nombre, string serie)
        {
            Personaje personaje = this.FindPersonaje(id);
            using (Transaction transaction =
                this.realmConnection.BeginWrite())
            {
                personaje.Nombre = nombre;
                personaje.Serie = serie;
                transaction.Commit();
            }
        }

        public void EliminarPersonaje(int id)
        {
            Personaje personaje = this.FindPersonaje(id);
            using (Transaction transaction = this.realmConnection.BeginWrite())
            {
                this.realmConnection.Remove(personaje);
                transaction.Commit();
            }
        }
    }
}
