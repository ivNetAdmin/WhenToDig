using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WhenToDig.Models;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class EditJobViewModel : BaseModel
    {
        private Job _job;

        #region Constructors
        public EditJobViewModel(INavigation navigation, string jobId)
        {
            this.Navigation = navigation;
            Title = "Update Job";

            _job = _realmInstance.Find<Job>(jobId);

            TypeList = new ObservableCollection<string> { "Cultivate", "General", "Preparation" };
            PlantList = GetPlantNameVarieties();
        }
        #endregion

        #region Properties
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
        public Command UpdateJobCommand // for ADD
        {
            get
            {
                return new Command(() => {
                    if (!string.IsNullOrEmpty(_job.Name))
                    {
                        _realmInstance.Write(() =>
                        {
                            _realmInstance.Add(_job, update: true); // Add the whole set of details
                    });

                        Navigation.PopAsync();
                    }
                });
            }
        }

        public Command DeleteJobCommand // for DELETE
        {
            get
            {
                return new Command(() => {
                    _realmInstance.Write(() =>
                    {
                        _realmInstance.Remove(_job);
                    });

                    Navigation.PopAsync();
                });
            }
        }
        #endregion
    }
}
