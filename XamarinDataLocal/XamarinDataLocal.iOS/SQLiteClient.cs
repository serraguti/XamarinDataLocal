using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using XamarinDataLocal.Dependencies;
using XamarinDataLocal.iOS;

[assembly: Dependency(typeof(SQLiteClient))]
namespace XamarinDataLocal.iOS
{
    public class SQLiteClient : IDataBase
    {
        public SQLiteConnection GetConnection()
        {
            String bbddfile = "HOSPITAL.db";
            String rutadocuments =
                Environment.GetFolderPath
                (Environment.SpecialFolder.Personal);
            String librarypath =
Path.Combine(rutadocuments, "..", "Library"
                            , "Databases");
            if (Directory.Exists(librarypath) == false)
            {
                Directory.CreateDirectory(librarypath);
            }
            String path =
                Path.Combine(librarypath, bbddfile);
            SQLiteConnection cn = new SQLiteConnection(path);
            return cn;
        }
    }
}