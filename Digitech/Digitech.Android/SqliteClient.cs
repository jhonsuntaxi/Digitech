using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Digitech.Droid;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SqliteClient))]
namespace Digitech.Droid
{
    class SqliteClient : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var document = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var parth = Path.Combine(document, "uisrael.db3");
            return new SQLiteAsyncConnection(parth);
        }
    }
}