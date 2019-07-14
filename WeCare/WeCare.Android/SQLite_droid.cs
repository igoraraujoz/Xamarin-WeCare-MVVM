using System;
using Xamarin.Forms;
using SQLite;
using System.IO;
using WeCare.Droid;
using WeCare.Data.Interfaces;

[assembly: Dependency(typeof(SQLite_droid))]
namespace WeCare.Droid
{
    public class SQLite_droid : ISQLite
    {
        public SQLite_droid()
        {
        }

        public SQLiteConnection GetConnection(string dbName)
        {
            var documents = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documents, dbName);
            return new SQLiteConnection(path);
        }

    }
}
