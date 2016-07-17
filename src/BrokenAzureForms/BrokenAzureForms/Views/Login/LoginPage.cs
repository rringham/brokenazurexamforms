using System;
using Xamarin.Forms;

namespace BrokenAzureForms.Views.Login
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();

			NavigationPage.SetHasNavigationBar(this, false);
		}

		private async void OnLogInButtonClicked(object sender, EventArgs args)
		{
			App.SetNavBarTextColor(Color.Black);
			
			IUserService userService = DependencyService.Get<IUserService>();
			bool authenticated = await userService.LoginWithAzureAD();
			if (authenticated)
			{
				App.SetNavBarTextColor(Color.White);
				await Navigation.PushAsync(new HomePage(), false);

				//Application.Current.MainPage = new HomePage();
				//Device.BeginInvokeOnMainThread(() =>
				//{
				//	Application.Current.MainPage = new NavigationPage(new HomePage());
				//});
			}
			else {
				App.SetNavBarTextColor(Color.White);
			}

			//await Navigation.PushAsync(new HomePage(), false);
		}
	}
}