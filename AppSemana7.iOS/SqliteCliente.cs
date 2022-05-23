using System;
using System.IO;
using AppSemana7.iOS;
using SQLite;

[assembly:Xamarin.Forms.Dependency(typeof(SqliteCliente))]
namespace AppSemana7.iOS
{
    public class SqliteCliente:Database
    {
        public SqliteCliente()
        {
        }

        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "uisrael.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
