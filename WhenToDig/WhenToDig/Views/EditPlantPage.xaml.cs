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
		public EditPlantPage (Plant plant)
		{
			InitializeComponent ();
            BindingContext = new EditPlantViewModel(Navigation, plant);
        }
	}
}