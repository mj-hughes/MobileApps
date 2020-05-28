using System;
using System.IO;

namespace FillInFables
{
    public class Constants
    {
        // For API url
        public static string BaseAddress = "https://madlibz.herokuapp.com/";
        public static string RequestAddress = "api/random";
        public static string Handshake = "?minlength=5&maxlength=16";
        public static string MadLibzInfo = BaseAddress + RequestAddress + Handshake;

        // For Database
        public const string DatabaseFilename = "PlayerSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }

    }
}
