using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace XamarinWithSQLLite.Models {
    public class Constants {
        public static bool IsDev = true;

        public static Color BackgroundColor = Color.FromArgb(58, 153, 215);
        public static Color MainTextColor = Color.White;
        public static int LoginIconHeight = 120;
        public static int btnBorder = 1;
        public static int btnBorderRadius = 5;
        public static Color btnBorderColor = Color.Black;
        public static Color btnColor = Color.White;


        //---------------------Login--------------------
        public static string LoginUrl = "https://test.com/api/Auth/Login";

        public static string NoInternetText = "No Internet, Please reconnect";
    }
}
