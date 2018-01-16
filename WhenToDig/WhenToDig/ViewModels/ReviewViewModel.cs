using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class ReviewViewModel : BaseModel
    {
        #region Constructors
        public ReviewViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Title = "Review";                 
        }
        #endregion     
    }
}
