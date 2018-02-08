using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class ViewImageViewModel : BaseModel
    {
        private string _source;

        public ViewImageViewModel(INavigation navigation, Image image)
        {
            Navigation = navigation;
            Title = "Image Viewer";

            _source = image.Source.ToString().Substring(6);
                //"/storage/emulated/0/Android/data/co.uk.ivNet.DiGiT/files/Pictures/temp/IMG-20180128-WA0000.jpg";
        }

        #region Properties      
        public ImageSource Source { get { return ImageSource.FromFile(_source); } }
        #endregion
    }
}
