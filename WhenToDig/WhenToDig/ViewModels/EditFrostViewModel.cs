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

        #region Properties
        public Frost Frost
        {
            get { return _frost; }
            set
            {
                _frost = value;
                OnPropertyChanged(); // Add the OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public Command UpdateFrostCommand // for ADD
        {
            get
            {
                return new Command(() => {
                    var frostId = string.Format("{0}{0}{0}", _frost.Year, _frost.Month, _frost.Day);
                    if (!string.IsNullOrEmpty(frostId))
                    {
                        _frost.FrostId = frostId;
                        _realmInstance.Write(() =>
                        {
                            _realmInstance.Add(_frost, true); // Add the whole set of details
                        });
                        Navigation.PopAsync();
                    }
                });
            }
        }

        public Command DeleteFrostCommand // for DELETE
        {
            get
            {
                return new Command(() => {
                    _realmInstance.Write(() =>
                    {
                        _realmInstance.Remove(_frost);
                    });

                    Navigation.PopAsync();
                });
            }
        }
        #endregion
    }
}
