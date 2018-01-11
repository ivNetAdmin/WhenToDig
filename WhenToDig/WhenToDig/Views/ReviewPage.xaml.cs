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
	public partial class ReviewPage : ContentPage
	{
		public ReviewPage ()
		{
			InitializeComponent ();            
        }

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ReviewViewModel(Navigation);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((ReviewViewModel)BindingContext).DisposeRealm();
        }
        #endregion
    }
}