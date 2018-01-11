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
	public partial class PlantListPage : ContentPage
	{
		public PlantListPage ()
		{            
            InitializeComponent ();
        }

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();            
            BindingContext = new PlantListViewModel(Navigation);
            PlantList.SelectedItem = null;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((PlantListViewModel)BindingContext).DisposeRealm();
        }
        #endregion
    }
}