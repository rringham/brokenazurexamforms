using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

[assembly: Xamarin.Forms.Dependency(typeof(BrokenAzureForms.Droid.DroidUserService))]
namespace BrokenAzureForms.Droid
{
	public class DroidUserService : IUserService
	{
		const string applicationURL = @"https://loginsalesbackend.azurewebsites.net";

		private MobileServiceClient _client;
		private MobileServiceUser _user;

		public DroidUserService()
		{
			// Initialize the Mobile Service client with the Mobile App URL, Gateway URL and key
			_client = new MobileServiceClient(applicationURL);
		}

		public MobileServiceUser User
		{
			get
			{
				return _user;
			}
		}

		public async Task<bool> LoginWithAzureAD()
		{
			try
			{
				_user = await _client.LoginAsync(Xamarin.Forms.Forms.Context, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public async Task Logout()
		{
			await _client.LogoutAsync();

			// Clear out webview cookies
			Android.Webkit.CookieSyncManager.CreateInstance(Android.App.Application.Context);
			Android.Webkit.CookieManager.Instance.RemoveAllCookie();

			_user = null;
		}
	}
}