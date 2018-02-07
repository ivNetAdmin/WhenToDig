using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenToDig.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhenToDig.ViewModels;
using Plugin.Media;
using WhenToDig.Helpers;

namespace WhenToDig.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPlantPage : ContentPage
	{
        private string _plantId;

        public EditPlantPage (string plantId)
		{
			InitializeComponent ();
            _plantId = plantId;
        }

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext == null) BindingContext = new EditPlantViewModel(Navigation, _plantId);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((EditPlantViewModel)BindingContext).DisposeRealm();
        }
        #endregion

        #region Commands
        private async void OnCameraButtonTapped(object sender, EventArgs e)
        {
            ImagePath.Text = string.Empty;
            Image.Source = string.Empty;

            var file = await Camera.TappedAsync();
            if (file != null)
            {
                ImagePath.Text = file.Path;
                Image = new Image { Source = ImageSource.FromStream(() => file.GetStream()) };
            }
        }
        private async void OnLibraryButtonTapped(object sender, EventArgs e)
        {
            ImagePath.Text = string.Empty;
            Image.Source = string.Empty;

            var file = await Camera.LibraryTappedAsync();
            if (file != null)
            {
                ImagePath.Text = file.Path;
                Image = new Image { Source = ImageSource.FromStream(() => file.GetStream()) };
            }
        }
        private void OnRemoveImageButtonTapped(object sender, EventArgs e)
        {
            ImagePath.Text = string.Empty;
            Image.Source = string.Empty;
        }
        #endregion
    }
}