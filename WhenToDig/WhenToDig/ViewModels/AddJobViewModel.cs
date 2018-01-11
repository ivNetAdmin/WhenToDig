using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WhenToDig.Models;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class AddJobViewModel : BaseModel
    {

        #region Constructors
        public AddJobViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Title = "Add Job";

            TypeList = new ObservableCollection<string> { "Cultivate", "General", "Preparation" };

            PlantList = new ObservableCollection<string> { "Carrot", "Pea", "Bean" };
        }
        #endregion

        #region Properties
        private Job _job = new Job();
        public Job Job
        {
            get { return _job; }
            set
            {
                _job = value;
                OnPropertyChanged(); // Add the OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _typeList;
        public ObservableCollection<string> TypeList
        {
            get { return _typeList; }
            set
            {
                _typeList = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }

        private ObservableCollection<string> _plantList;
        public ObservableCollection<string> PlantList
        {
            get { return _plantList; }
            set
            {
                _plantList = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }
        #endregion

        #region Commands
        public Command AddJobCommand // for ADD
        {
            get
            {
                return new Command(() => {
                    if (!string.IsNullOrEmpty(_job.Name))
                    {               
                        _job.JobId = Guid.NewGuid().ToString();
                        if (string.IsNullOrEmpty(_job.Type)) _job.Type = "General";
                        _realmInstance.Write(() =>
                        {
                            _realmInstance.Add(_job); // Add the whole set of details
                        });

                        Navigation.PopAsync();
                    }
                });
            }
        }
        #endregion
    }
}
