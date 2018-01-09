using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class PlantListViewModel : BaseModel
    {
        #region Constructors
        public PlantListViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Title = "Plant List";
        }
        #endregion
    }
}
