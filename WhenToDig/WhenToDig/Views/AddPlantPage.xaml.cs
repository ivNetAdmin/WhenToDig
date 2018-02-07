using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhenToDig.Helpers;
using WhenToDig.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace WhenToDig.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPlantPage : ContentPage
	{
		public AddPlantPage ()
		{
            InitializeComponent();
            

            //takePhoto.Clicked += async (sender, args) =>
            //{
            //    await CrossMedia.Current.Initialize();

            //    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            //    {
            //        await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
            //        return;
            //    }

            //    var cakes =  Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); // data/user/0/co.uk.ivNet.DiGiT/files


            //    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //    {                   
            //       // Directory = "Sample",
            //        Name = "test.jpg"
            //    });

            //    //var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //    //{
            //    //    Directory = "Pictures",
            //    //    Name = DateTime.Now + ".jpg",
            //    //    SaveToAlbum = true,
            //    //    CompressionQuality = 75,
            //    //    CustomPhotoSize = 50,
            //    //    PhotoSize = PhotoSize.MaxWidthHeight,
            //    //    MaxWidthHeight = 2000,
            //    //    DefaultCamera = CameraDevice.Front
            //    //});

            //    if (file == null)
            //        return;

            //    await DisplayAlert("File Location", file.Path, "OK");

            //    image.Source = ImageSource.FromStream(() =>
            //    {
            //        var stream = file.GetStream();
            //        file.Dispose();
            //        return stream;
            //    });
            //};

        }

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext == null) BindingContext = new AddPlantViewModel(Navigation);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((AddPlantViewModel)BindingContext).DisposeRealm();
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