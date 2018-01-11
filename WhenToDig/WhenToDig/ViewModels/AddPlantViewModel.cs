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
                    if (!string.IsNullOrEmpty(_plant.Name))
                    {                        
                        _plant.PlantId = Guid.NewGuid().ToString();
                        if (string.IsNullOrEmpty(_plant.Variety)) _plant.Variety = "Common";
                        _realmInstance.Write(() =>
                        {
                            _realmInstance.Add(_plant); // Add the whole set of details
                    });

                        Navigation.PopAsync();
                    }
                });
            }
        }
        #endregion
    }
}
