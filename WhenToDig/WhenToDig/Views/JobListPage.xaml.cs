using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenToDig.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhenToDig.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JobListPage : ContentPage
	{
		public JobListPage()
		{
			InitializeComponent ();
        }

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new JobListViewModel(Navigation);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((JobListViewModel)BindingContext).DisposeRealm();
        }
        #endregion
    }
}