using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class FrostListViewModel : BaseModel
    {
        #region Constructors
        public FrostListViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Title = "Frost List";
        }
        #endregion
    }
}
