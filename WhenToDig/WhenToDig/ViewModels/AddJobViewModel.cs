using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

            PlantList = GetPlantNames();           

            Job.Date = DateTime.Today;
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
                return new Command(() =>
                {
                    if (!string.IsNullOrEmpty(_job.Name))
                    {
                        if (string.IsNullOrEmpty(_job.Type)) _job.Type = "General";
                        if (string.IsNullOrEmpty(_job.Plant)) _job.Type = "All";
                        _job.JobId = string.Format("{0}{1}{2}{3}", 
                            _job.Name, 
                            _job.Plant, 
                            _job.Type, 
                            _job.Date.ToString("yyyyMMdd")).ToLower();

                        _realmInstance.Write(() =>
                        {
                            _realmInstance.Add(_job, true); // Add the whole set of details
                        });

                        Navigation.PopAsync();
                    }
                });
            }
        }
        #endregion
    }
}
