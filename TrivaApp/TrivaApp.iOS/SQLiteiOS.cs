using System;
using System.IO;
using SQLite;
using TrivaApp.iOS;
using TrivaApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteiOS))]
namespace TrivaApp.iOS
{
public class SQLiteiOS : ISQLite
    {
        public SQLiteConnection GetSQLiteConnection()
        {
            var sqliteFilename = "testing.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);

            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}

