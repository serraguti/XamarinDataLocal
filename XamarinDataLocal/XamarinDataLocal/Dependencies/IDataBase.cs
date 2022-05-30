using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinDataLocal.Dependencies
{
    public interface IDataBase
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
