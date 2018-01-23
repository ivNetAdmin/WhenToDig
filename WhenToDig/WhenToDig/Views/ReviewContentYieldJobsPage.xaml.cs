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
	public partial class ReviewContentYieldJobsPage : ContentPage
	{
        string _yieldId;
        public ReviewContentYieldJobsPage(string yieldId)
        {
            InitializeComponent();
            _yieldId = yieldId;
        }

        #region Page Events
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ReviewContentYieldJobsViewModel(Navigation, _yieldId);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((ReviewContentYieldJobsViewModel)BindingContext).DisposeRealm();
        }
        #endregion
    }
}