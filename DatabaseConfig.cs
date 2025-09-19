using System;
using System.IO;

namespace DrugstoreManagement
{
    static class DatabaseConfig
    {
        // Data file in |DataDirectory| to match App.config; defaults to BaseDirectory if DataDirectory not set
        public static string DatabaseFile => Path.Combine(AppDomain.CurrentDomain.GetData("DataDirectory")?.ToString() ?? AppDomain.CurrentDomain.BaseDirectory, "DrugstoreDB.accdb");

        // Provider uses Microsoft.ACE.OLEDB.12.0; ensure Access Database Engine (ACE) is installed.
        public static string ConnectionString => $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={DatabaseFile};Persist Security Info=False;";
    }
}