using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WhenToDig.Models;
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

            Plants = new ObservableCollection<Plant>(_realmInstance.All<Plant>().ToList());
        }
        #endregion

        #region Properties
        private ObservableCollection<Plant> _listOfPlants;
        public ObservableCollection<Plant> Plants
        {
            get { return _listOfPlants; }
            set
            {
                _listOfPlants = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }

        private string selectedItemText;
        public string SelectedItemText
        {
            get { return selectedItemText; }
            set
            {
                selectedItemText = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand ItemSelectedCommand { get; private set; }
        #endregion
    }
}
