using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWithSQLLite.Models;

namespace XamarinWithSQLLite.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
            btn_Login.Clicked += (sender, e) => {
                User user = new User(entry_Username.Text,entry_Password.Text);
                if (user.CheckInformation()) {
                    DisplayAlert("Login Information","Login Success", "OK");
                } else{
                    DisplayAlert("Login Information", "Login not Valid", "OK");
                }
            };
        }

    }
}