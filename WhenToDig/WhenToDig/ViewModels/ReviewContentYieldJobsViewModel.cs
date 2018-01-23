using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WhenToDig.Models;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class ReviewContentYieldJobsViewModel : BaseModel
    {
        
        public ReviewContentYieldJobsViewModel(INavigation navigation, string yieldId)
        {
            this.Navigation = navigation;

            Yield = _realmInstance.Find<Yield>(yieldId);

            RelatedJobs = new ObservableCollection<Job>(GetRelatedJobs(_yield.Plant, _yield.Year));
            UnrelatedJobs = new ObservableCollection<Job>(GetUnRelatedJobs(_yield.Year));
        }

        #region Properties
        private Yield _yield;
        public Yield Yield
        {
            get { return _yield; }
            set
            {
                _yield = value;
                OnPropertyChanged(); // Add the OnPropertyChanged();
            }
        }
        private ObservableCollection<Job> _listOfRelatedJobs;
        public ObservableCollection<Job> RelatedJobs
        {
            get { return _listOfRelatedJobs; }
            set
            {
                _listOfRelatedJobs = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }
        private ObservableCollection<Job> _listOfUnrelatedJobs;
        public ObservableCollection<Job> UnrelatedJobs
        {
            get { return _listOfUnrelatedJobs; }
            set
            {
                _listOfUnrelatedJobs = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }
        #endregion

        #region Privaye methods
        private List<Job> GetRelatedJobs(string plant,int year)
        {
            var startDate = new DateTimeOffset(new DateTime(year - 1, 9, 30));
            var endDate = new DateTimeOffset(new DateTime(year, 10, 01));
            return new List<Job>(
                _realmInstance.All<Job>()
                .Where(x => x.Plant == plant && x.Date > startDate && x.Date < endDate)
                .OrderBy(x => x.Type)
                .ThenBy(x => x.Date).ToList());

        }
        private List<Job> GetUnRelatedJobs(int year)
        {
            var startDate = new DateTimeOffset(new DateTime(year - 1, 9, 30));
            var endDate = new DateTimeOffset(new DateTime(year, 10, 01));
            return new List<Job>(
                _realmInstance.All<Job>()
                .Where(x => x.Type == "General" && x.Date > startDate && x.Date < endDate)
                .OrderBy(x => x.Type)
                .ThenBy(x => x.Date).ToList());

        }
        #endregion
    }
}
