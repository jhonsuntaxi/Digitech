using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using Digitech.iOS;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteClient))]
namespace Digitech.iOS
{
    class SqliteClient : Database
    {

        public SQLiteAsyncConnection GetConnection()
        {
            var document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var parth = Path.Combine(document, "tienda_virtual");
            return new SQLiteAsyncConnection(parth);
        }
    }
}