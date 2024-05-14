using System;
using System.Data.SqlTypes;

namespace TrivaApp.Services
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetSQLiteConnection();
    }
}

