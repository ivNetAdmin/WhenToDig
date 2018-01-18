
using System;
using Xamarin.Forms;

namespace WhenToDig
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            try
            {             
                MainPage = new NavigationPage(new WhenToDig.MainPage());
            }catch(Exception ex)
            {
                var cakes = ex;
            }
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
