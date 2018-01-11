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
	public partial class AddJobPage : ContentPage
	{
		public AddJobPage ()
		{
			InitializeComponent ();
		}

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new AddJobViewModel(Navigation);
            TypeList.SelectedItem = "General";
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((AddJobViewModel)BindingContext).DisposeRealm();
        }
        #endregion       
    }
}