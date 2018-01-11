using System;
using System.Collections.Generic;
using System.Text;
using WhenToDig.Models;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class EditPlantViewModel
    {
        private INavigation navigation;
        private Plant plant;

        public EditPlantViewModel(INavigation navigation, Plant plant)
        {
            this.navigation = navigation;
            this.plant = plant;
        }
    }
}
