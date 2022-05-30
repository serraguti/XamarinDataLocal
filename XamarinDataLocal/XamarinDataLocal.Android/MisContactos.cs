using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinDataLocal.Dependencies;
using XamarinDataLocal.Droid;
using XamarinDataLocal.Models;

[assembly: Dependency(typeof(MisContactos))]
namespace XamarinDataLocal.Droid
{
    public class MisContactos : IContactos
    {
        public async Task<List<Contacto>> GetContactosAsync()
        {
            Contacto selectedContact = new Contacto();
            List<Contacto> lista = new List<Contacto>();
            var uri = ContactsContract.CommonDataKinds.Phone.ContentUri;
            string[] projection = {
                ContactsContract.Contacts.InterfaceConsts.Id,
                ContactsContract.Contacts.InterfaceConsts.DisplayName,
                ContactsContract.CommonDataKinds.Phone.Number
            };
            var cursor = Xamarin.Forms.Forms.Context.ContentResolver.Query(uri, projection, null, null, null);
            if (cursor.MoveToFirst())
            {
                do
                {
                    lista.Add(new Contacto()
                    {
                        Nombre = cursor.GetString(cursor.GetColumnIndex(projection[1]))
                        ,
                        Telefono = cursor.GetString(cursor.GetColumnIndex(projection[2]))
                    });
                } while (cursor.MoveToNext());
            }
            return lista;
        }
    }
}