using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BrokenAzureForms
{
	public partial class HomePage : ContentPage
	{
		public HomePage()
		{
			InitializeComponent();

			App.SetNavBarTextColor(Color.Black);
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}

