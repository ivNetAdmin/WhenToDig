
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using WhenToDig.Helpers;
using WhenToDig.Models;
using WhenToDig.Views;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class BaseModel : INotifyPropertyChanged
    {
        internal Realm _realmInstance;

        #region Constructors
        public BaseModel()
        {
             _realmInstance = Realm.GetInstance();
        }

        #endregion

        #region Properties
        public INavigation Navigation { get; set; }
        public string Title { get; set; }
        #endregion

        #region Navigation Icons
        public ImageSource MainPageIcon { get { return ImageSource.FromFile("icon.png"); } }
        public ImageSource PlantListIcon { get { return ImageSource.FromFile("icon.png"); } }
        public ImageSource JobListIcon { get { return ImageSource.FromFile("icon.png"); } }
        public ImageSource FrostListIcon { get { return ImageSource.FromFile("icon.png"); } }
        public ImageSource YieldListIcon { get { return ImageSource.FromFile("icon.png"); } }
        public ImageSource ReviewIcon { get { return ImageSource.FromFile("icon.png"); } }
        public ImageSource AddIcon { get { return ImageSource.FromFile("add.png"); } }
        public ImageSource CancelIcon { get { return ImageSource.FromFile("cancel.png"); } }
        public ImageSource DeleteIcon { get { return ImageSource.FromFile("delete.png"); } }
        public ImageSource SaveIcon { get { return ImageSource.FromFile("save.png"); } }
        #endregion

        #region Navigation Commands
        public ICommand NavigationClickedCommand {

            get
            {
                return new Command<WTGPage>((pageId) =>
                {
                    switch (pageId)
                    {
                        case WTGPage.PlantList:
                            Navigation.PushAsync(new PlantListPage());
                            break;
                        case WTGPage.JobList:
                            Navigation.PushAsync(new JobListPage());
                            break;
                        case WTGPage.FrostList:
                            Navigation.PushAsync(new FrostListPage());
                            break;
                        case WTGPage.YieldList:
                            Navigation.PushAsync(new YieldListPage());
                            break;
                        case WTGPage.Review:
                            Navigation.PushAsync(new ReviewPage());
                            break;
                        case WTGPage.AddPlant:
                            Navigation.PushAsync(new AddPlantPage());
                            break;
                        case WTGPage.AddJob:
                            Navigation.PushAsync(new AddJobPage());
                            break;
                        case WTGPage.AddYield:
                            Navigation.PushAsync(new AddYieldPage());
                            break;
                        case WTGPage.Cancel:
                            Navigation.PopAsync();
                            break;
                        default:
                            //App.Current.MainPage = new NavigationPage(new MainPage());
                            Navigation.PopToRootAsync();
                            break;
                    }
                });
            }
        }        

        #endregion

        #region Page Events
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Shared Methods
        internal ObservableCollection<Job> GetJobs()
        {
            return new ObservableCollection<Job>(
                _realmInstance.All<Job>()
                .OrderBy(x => x.Date)
                .ThenBy(x => x.Plant)
                .ThenBy(x => x.Type).ToList());

        }
        internal ObservableCollection<Plant> GetPlants()
        {
            return new ObservableCollection<Plant>(
                 _realmInstance.All<Plant>()
                 .OrderBy(x => x.Name)
                 .ThenBy(x => x.Variety).ToList());
        }
        internal ObservableCollection<string> GetPlantNames()
        {
            var plants = new List<Plant>(
               _realmInstance.All<Plant>()
               .OrderBy(x => x.Name).ThenBy(x => x.Variety).ToList());

            var plantnames = new List<string> { "All" };
            foreach (var plant in plants)
            {
                if (!plantnames.Contains(plant.Name))
                {
                    plantnames.Add(plant.Name);
                }
            }

            return new ObservableCollection<string>(plantnames);
        }
        internal ObservableCollection<string> GetPlantNameVarieties()
        {
            var plants = new List<Plant>(
               _realmInstance.All<Plant>()
               .OrderBy(x => x.Name).ThenBy(x => x.Variety).ToList());

            var plantnames = new List<string>();
            foreach (var plant in plants)
            {
                var plantVariety = string.Format("{0} {1}", plant.Name, plant.Variety);
                if (!plantnames.Contains(plantVariety))
                {
                    plantnames.Add(plantVariety);
                }
            }

            return new ObservableCollection<string>(plantnames);
        }        
        internal ObservableCollection<Yield> GetYields()
        {
            return new ObservableCollection<Yield>(
                 _realmInstance.All<Yield>()
                 .OrderBy(x => x.Year)
                 .ThenBy(x => x.Plant).ToList());
        }
        internal ObservableCollection<int> GetYears()
        {
            var rtnList = new ObservableCollection<int>();
            var earliestJob = GetJobs().FirstOrDefault<Job>();

            if (earliestJob == null) return rtnList;

            for (var i = earliestJob.Date.Year; i < DateTime.Now.AddYears(1).Year; i++)
            {
                rtnList.Add(i);
            }

            return rtnList;
        }
        #endregion
        internal void DisposeRealm()
        {
            //if (_realmInstance != null)
            //    _realmInstance.Dispose();
        }
    }
}
