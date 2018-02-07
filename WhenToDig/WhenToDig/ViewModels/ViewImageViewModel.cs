using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class ViewImageViewModel : BaseModel
    {
        private Image _image;

        public ViewImageViewModel(INavigation navigation, Image image)
        {
            Navigation = navigation;
            Title = "Image Viewer";

            ShowImage = image;
        }

        #region Properties
        public Image ShowImage
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged(); // Add the OnPropertyChanged();
            }
        }
        #endregion
    }
}
