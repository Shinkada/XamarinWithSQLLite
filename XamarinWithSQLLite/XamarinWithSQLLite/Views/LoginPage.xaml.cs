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
            Init();
            btn_Login.Clicked += Btn_Login_Clicked;
        }

        private void Btn_Login_Clicked(object sender, EventArgs e) {
            
            if(!string.IsNullOrEmpty(entry_Username.Text) && !string.IsNullOrEmpty(entry_Password.Text) ) {
                User user = new User(entry_Username.Text, entry_Password.Text);
                if( user.CheckInformation() ) {
                    DisplayAlert("Login Information", "Login Success", "OK");
                } else {
                    DisplayAlert("Login Information", "Login not Valid", "OK");
                }
            } else {
                DisplayAlert("Anmeldung Information", "Benutzername und Passwort muss nicht leer sein", "OK");
                entry_Username.Focus();
            }
            }
    
        void Init() {
            BackgroundColor = Constants.BackgroundColor;
            lbl_Username.TextColor = Constants.MainTextColor;
            lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            entry_Username.Completed += (s, e) => entry_Password.Focus();
            entry_Password.Completed += (s, e) => Btn_Login_Clicked(s, e);
        }

         

    }
}