using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XamarinDataLocal.Dependencies;
using XamarinDataLocal.Models;

namespace XamarinDataLocal.Repositories
{
    public class RepositoryDepartamentos
    {
        SQLiteConnection cn;

        public RepositoryDepartamentos()
        {
            this.cn =
                DependencyService.Get<IDataBase>().GetConnection();
        }

        public void CrearBBDD()
        {
            this.cn.DropTable<Departamento>();
            this.cn.CreateTable<Departamento>();
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.cn.Table<Departamento>()
                           select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int id)
        {
            var consulta = from datos in this.cn.Table<Departamento>()
                           where datos.IdDepartamento == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        private int GetMaxIdDepartamento()
        {
            if (this.GetDepartamentos().Count == 0)
            {
                return 1;
            }
            else
            {
                return this.GetDepartamentos().Max(z => z.IdDepartamento) + 1;
            }
        }

        public void InsertarDepartamento(string nombre, string localidad)
        {
            Departamento departamento = new Departamento
            {
                IdDepartamento = this.GetMaxIdDepartamento(),
                Nombre = nombre, 
                Localidad = localidad
            };
            this.cn.Insert(departamento);
        }

        public void EliminarDepartamento(int id)
        {
            Departamento departamento = this.FindDepartamento(id);
            this.cn.Delete(departamento);
        }

        public void ModificarDepartamento(int id
            ,string nombre, string localidad)
        {
            Departamento departamento = this.FindDepartamento(id);
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            this.cn.Update(departamento);
        }
    }
}
