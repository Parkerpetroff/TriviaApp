using System;
using System.IO;
using TrivaApp.Droid;
using TrivaApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteAndroid))]
namespace TrivaApp.Droid
{

    public class SQLiteAndroid : ISQLite
    {
        public SQLite.SQLiteConnection GetSQLiteConnection()
        {
            var fileName = "testing.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var connection = new SQLite.SQLiteConnection(path, true);

            return connection;
        }
    }
}

