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
	public partial class AddYieldPage : ContentPage
	{
		public AddYieldPage ()
		{
			InitializeComponent ();
		}

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new AddYieldViewModel(Navigation);
            YearList.SelectedIndex = YearList.ItemsSource.Count - 1;
            PlantList.SelectedIndex = 0;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((AddYieldViewModel)BindingContext).DisposeRealm();
        }
        #endregion
    }
}