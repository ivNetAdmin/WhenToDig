using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WhenToDig.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhenToDig.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditFrostPage : ContentPage
    {
        string _frostId;
        public EditFrostPage(string frostId)
        {
            InitializeComponent();
            _frostId = frostId;

        }

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new EditFrostViewModel(Navigation, _frostId);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((EditFrostViewModel)BindingContext).DisposeRealm();
        }
        #endregion
    }
}