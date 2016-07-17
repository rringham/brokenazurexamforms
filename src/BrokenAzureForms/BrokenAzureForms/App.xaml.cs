using BrokenAzureForms.Views.Login;
using Xamarin.Forms;

namespace BrokenAzureForms
{
	public partial class App : Application
	{
		private static NavigationPage _mainNavigationPage;
		
		public App()
		{
			InitializeComponent();

			_mainNavigationPage = new NavigationPage(new LoginPage());
			_mainNavigationPage.BarTextColor = Color.White;

			MainPage = _mainNavigationPage;
		}

		public static void SetNavBarTextColor(Color color)
		{
			_mainNavigationPage.BarTextColor = color;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

