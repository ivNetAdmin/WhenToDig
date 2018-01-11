
using Realms;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using WhenToDig.Helpers;
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
                        case WTGPage.Review:
                            Navigation.PushAsync(new ReviewPage());
                            break;
                        case WTGPage.AddPlant:
                            Navigation.PushAsync(new AddPlantPage());
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

        internal void DisposeRealm()
        {
            //if (_realmInstance != null)
            //    _realmInstance.Dispose();
        }
    }
}
