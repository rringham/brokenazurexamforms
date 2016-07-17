using System;
using System.Threading.Tasks;
using Foundation;
using Microsoft.WindowsAzure.MobileServices;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(BrokenAzureForms.iOS.IosUserService))]
namespace BrokenAzureForms.iOS
{
	public class IosUserService : IUserService
	{
		const string applicationURL = @"YOUR-AZURE-APP-SERVICE-URL-HERE";

		private MobileServiceClient _client;
		private MobileServiceUser _user;

		public IosUserService()
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
				var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
				_user = await _client.LoginAsync(viewController, MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
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

			foreach (var cookie in NSHttpCookieStorage.SharedStorage.Cookies)
			{
				NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);
			}

			_user = null;
		}
	}
}