using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinWithSQLLite.Data;
using XamarinWithSQLLite.Droid.Data;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkConnection))]
namespace XamarinWithSQLLite.Droid.Data {
    public class NetworkConnection : INetworkConnection {
        public bool IsConnected{ get; set; }
        public void checkNetworConnection() {
            var ConnectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var ActiveNetworkInfo = ConnectivityManager.ActiveNetworkInfo;
            if(ActiveNetworkInfo != null && ActiveNetworkInfo.IsConnected) {
                IsConnected = true;
            } else {
                IsConnected = false;
            }
        }
    }
}