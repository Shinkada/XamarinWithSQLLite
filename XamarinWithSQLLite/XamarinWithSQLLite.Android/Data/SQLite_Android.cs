using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using XamarinWithSQLLite.Data;
using Xamarin.Forms;
using XamarinWithSQLLite.Droid.Data;

[assembly: Dependency(typeof(SQLite_Android))]
namespace XamarinWithSQLLite.Droid.Data {
    public class SQLite_Android : ISQLite{
        public SQLite_Android() { }
        public SQLiteConnection GetConnection() {
            var sqliteFileName = "TestDB.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}