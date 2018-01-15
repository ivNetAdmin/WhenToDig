﻿using System;
using System.Collections.Generic;
using System.Text;
using WhenToDig.Models;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class AddFrostViewModel : BaseModel
    {
        #region Constructors
        public AddFrostViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Title = "Add Frost";
        }
        #endregion

        #region Properties
        private Frost _frost = new Frost();
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
        public Command AddPlantCommand // for ADD
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
        #endregion
    }
}
