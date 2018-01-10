
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using WhenToDig.Views;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class BaseModel : INotifyPropertyChanged
    {
        public enum WTGPage {
            Home = 0,
            PlantList = 1,
            JobList = 2,
            FrostList = 3,
            Review = 4
        }

        #region Constructors
        public BaseModel()
        {
            NavigationClickedCommand = new Command<string>(NavigationClicked);            
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
        #endregion

        #region Navigation Commands
        public ICommand NavigationClickedCommand { get; private set; }

        private void NavigationClicked(string pageId)
        {
            switch (Convert.ToInt32(pageId))
            {
                case (int)WTGPage.PlantList:
                    Navigation.PushAsync(new PlantListPage());
                    break;
                case (int)WTGPage.JobList:
                    Navigation.PushAsync(new JobListPage());
                    break;
                case (int)WTGPage.FrostList:
                    Navigation.PushAsync(new FrostListPage());                    
                    break;
                case (int)WTGPage.Review:
                    Navigation.PushAsync(new ReviewPage());                    
                    break;
                default:
                    //App.Current.MainPage = new NavigationPage(new MainPage());

                    break;

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
    }
}
