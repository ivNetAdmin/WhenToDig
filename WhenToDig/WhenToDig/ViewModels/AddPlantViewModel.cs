using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class AddPlantViewModel : BaseModel
    {
        #region Constructors
        public AddPlantViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Title = "Add Plant";
        }
        #endregion
    }
}
