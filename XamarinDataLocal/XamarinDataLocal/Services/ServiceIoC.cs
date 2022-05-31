using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinDataLocal.Repositories;
using XamarinDataLocal.ViewModels;

namespace XamarinDataLocal.Services
{
    public class ServiceIoC
    {
        private IContainer container;

        public ServiceIoC()
        {
            this.RegisterDependencies();
        }

        //METODO PRIVADO QUE REGISTRARA LAS CLASES
        //A INYECTAR EN EL CONTENEDOR
        private void RegisterDependencies()
        {
            ContainerBuilder builder = new ContainerBuilder();
            //EN ESTE BUILDER ES DONDE REGISTRAMOS LAS CLASES PARA 
            //LA INYECCION
            builder.RegisterType<RepositoryPersonajes>();
            builder.RegisterType<PersonajesViewModel>();
            //CREAMOS EL CONTENEDOR
            this.container = builder.Build();
        }

        public PersonajesViewModel PersonajesViewModel
        {
            get
            {
                return this.container.Resolve<PersonajesViewModel>();
            }
        }
    }
}
