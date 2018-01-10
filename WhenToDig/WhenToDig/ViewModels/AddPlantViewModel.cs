using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WhenToDig.Models;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class AddPlantViewModel : BaseModel
    {
        //Realm _realmInstance = Realm.GetInstance();

        #region Constructors
        public AddPlantViewModel(INavigation navigation)
        {          
            this.Navigation = navigation;
            Title = "Add Plant";
        }
        #endregion

        #region Properties
        private Plant _plant = new Plant();
        public Plant Plant
        {
            get { return _plant; }
            set
            {
                _plant = value;
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
                    // for auto increment the id upon adding
                    _plant.PlantId = _realmInstance.All<Plant>().Count() + 1;
                    _realmInstance.Write(() =>
                    {
                        _realmInstance.Add(_plant); // Add the whole set of details
                    });

                    Navigation.PopAsync();
                });
            }
        }
        #endregion
    }
}
