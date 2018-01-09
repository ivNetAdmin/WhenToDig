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
            BindingContext = new PlantListViewModel(Navigation);
        }
	}
}