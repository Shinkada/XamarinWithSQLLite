using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWithSQLLite.Data;
using XamarinWithSQLLite.Models;
using XamarinWithSQLLite.Views;

namespace XamarinWithSQLLite {
	public partial class App : Application {

		static TokenDatabaseController tokenDatabase;
		static UserDatabaseController userDatabase;
		static RestService restService;
		private static Label lableScreen;
		private static bool hasInternet;
		private static Page currentPage;
		private static Timer timer;
		private static bool noInterShow;

		public App() {
			InitializeComponent();

			MainPage = new LoginPage();
		}

		protected override void OnStart() {
		}

		protected override void OnSleep() {
		}

		protected override void OnResume() {
		}



		public static UserDatabaseController UserDatabase {
			get {
				if (userDatabase == null) {
					userDatabase = new UserDatabaseController();
				}
				return userDatabase;
			}
		}
		public static TokenDatabaseController TokenDatabase {
			get {
				if (tokenDatabase == null) {
					tokenDatabase = new TokenDatabaseController();
				}
				return tokenDatabase;
			}
		}

		public static RestService RestService {
			get {
				if (restService == null) {
					restService = new RestService();
				}
				return restService;
			}
		}


		//------------------------- Internet Connection ----------------------------
		public static void StartCheckIfInternet(Label label, Page page) {
			lableScreen = label;
			label.Text = Constants.NoInternetText;
			label.IsVisible = false;
			hasInternet = true;
			currentPage = page;

			if (timer == null) {
				timer = new Timer((e) => {
					CheckInternetOverTime();
				},null,10,(int)TimeSpan.FromSeconds(3).TotalSeconds);
			}
		}

		private static void CheckInternetOverTime() {
			var networkConnection = DependencyService.Get<INetworkConnection>();
			networkConnection.checkNetworConnection();
			if (!networkConnection.IsConnected) {
				Device.BeginInvokeOnMainThread(async () => {
					if (hasInternet) {
						if (! noInterShow) {
							hasInternet = false;
							lableScreen.IsVisible = true;
							await ShowDisplayAlert();
						}
					}
				});
			} else {
				Device.BeginInvokeOnMainThread(() => {
					hasInternet = true;
					lableScreen.IsVisible = false;

				});
			}
		}

		public static async Task<bool> CheckIfInternt() {
			var networkConnection = DependencyService.Get<INetworkConnection>();
			networkConnection.checkNetworConnection();
			return networkConnection.IsConnected;
			
		}

		public static async Task<bool> CheckIfInternetAlertAsync() {
			var networkConnection = DependencyService.Get<INetworkConnection>();
			networkConnection.checkNetworConnection();
			if (!networkConnection.IsConnected) {
				if (!noInterShow) {
					await ShowDisplayAlert();
				}
				return false;
			}
			return true;
		}

		private static async Task ShowDisplayAlert() {
			noInterShow = false;
			await currentPage.DisplayAlert("Internet", "Device has no Internet", "Ok");
			noInterShow = false;
		}
	}
}
