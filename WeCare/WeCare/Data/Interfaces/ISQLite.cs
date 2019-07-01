using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeCare.Data.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection(string dbName);
    }
}
