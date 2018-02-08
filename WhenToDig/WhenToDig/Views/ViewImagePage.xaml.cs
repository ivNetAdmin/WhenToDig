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
	public partial class ViewImagePage : ContentPage
	{
        private Image _image;
        public ViewImagePage (Image image)
		{
			InitializeComponent ();
            _image = image;
        }

        #region Page Events
        protected override void OnAppearing()
        {           
            BindingContext = new ViewImageViewModel(Navigation, _image);
            //ShowImage = new Image { Source = _image.Source };
            base.OnAppearing();            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();            
        }
        #endregion
    }
}