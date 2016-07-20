using System;
using System.Threading.Tasks;
using Android.Content;
using Microsoft.WindowsAzure.MobileServices;

[assembly: Xamarin.Forms.Dependency(typeof(BrokenAzureForms.Droid.DroidUserService))]
namespace BrokenAzureForms.Droid
{
	public class DroidUserService : IUserService
	{
		const string applicationURL = @"YOUR-AZURE-APP-SERVICE-URL-HERE";

		private MobileServiceClient _client;
		private MobileServiceUser _user;

		public static Context Context { get; set; }

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
			if (Context == null)
			{
				return false;
			}
			
			try
			{
				_user = await _client.LoginAsync(Context, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
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