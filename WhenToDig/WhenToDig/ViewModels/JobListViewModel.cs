using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhenToDig.Models;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class JobListViewModel : BaseModel
    {        
        #region Constructors
        public JobListViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Title = "Job List";            
        }
        #endregion
       
    }
}
