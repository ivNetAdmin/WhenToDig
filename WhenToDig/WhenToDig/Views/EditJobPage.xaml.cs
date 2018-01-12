using WhenToDig.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhenToDig.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditJobPage : ContentPage
	{
        string _jobId;
        public EditJobPage (string jobId)
		{
			InitializeComponent ();
            _jobId = jobId;

        }

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new EditJobViewModel(Navigation, _jobId);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((EditJobViewModel)BindingContext).DisposeRealm();
        }
        #endregion
    }
}