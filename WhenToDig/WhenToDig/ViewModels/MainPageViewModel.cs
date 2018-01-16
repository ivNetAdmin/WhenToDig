
using Realms;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class MainPageViewModel : BaseModel
    {
        #region Constructors
        public MainPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Title = "DiGiT";           
        }
        #endregion
    }
}
