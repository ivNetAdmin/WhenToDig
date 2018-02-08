using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenToDig.ViewModels;
using WhenToDig.Views;
using Xamarin.Forms;

namespace WhenToDig
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();            
        }

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();           
            BindingContext = new MainPageViewModel(Navigation);                       
            ((MainPageViewModel)BindingContext).PageAppearingSetDateRange();
            JobList.SelectedItem = null;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((MainPageViewModel)BindingContext).DisposeRealm();
        }
        #endregion

        #region Commands
        private async void OnImageButtonTapped(object sender, EventArgs e)
        {
            //var file = ((Image)sender).Source;
            await Navigation.PushAsync(new ViewImagePage((Image)sender));
        }
        #endregion
    }
}
