using System;
using System.Collections.Generic;
using System.Text;
using WhenToDig.Models;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    class EditFrostViewModel : BaseModel
    {
        private Frost _frost;

        #region Constructors
        public EditFrostViewModel(INavigation navigation, string frostId)
        {
            this.Navigation = navigation;
            Title = "Update Frost";

            _frost = _realmInstance.Find<Frost>(frostId);
        }
        #endregion
    }
}
