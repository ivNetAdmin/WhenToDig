using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenToDig.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhenToDig.ViewModels;

namespace WhenToDig.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPlantPage : ContentPage
	{
        string _plantId;

        public EditPlantPage (string plantId)
		{
			InitializeComponent ();
            _plantId = plantId;
        }

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new EditPlantViewModel(Navigation, _plantId);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((EditPlantViewModel)BindingContext).DisposeRealm();
        }
        #endregion
    }
}