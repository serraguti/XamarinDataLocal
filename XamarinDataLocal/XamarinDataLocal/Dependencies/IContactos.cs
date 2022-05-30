using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinDataLocal.Models;

namespace XamarinDataLocal.Dependencies
{
    public interface IContactos
    {
        Task<List<Contacto>> GetContactosAsync();
    }
}
