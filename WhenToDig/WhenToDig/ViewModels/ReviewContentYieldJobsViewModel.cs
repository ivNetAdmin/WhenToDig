using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhenToDig.Models;
using Xamarin.Forms;

namespace WhenToDig.ViewModels
{
    public class ReviewContentYieldJobsViewModel : BaseModel
    {
        private Yield _yield;
        public ReviewContentYieldJobsViewModel(INavigation navigation, string yieldId)
        {
            this.Navigation = navigation;
            Title = "Yield Jobs";

            _yield = _realmInstance.Find<Yield>(yieldId);

            var relatedJobs = GetRelatedJobs(_yield.Plant, _yield.Year);
            var unrelatedJobs = GetUnRelatedJobs(_yield.Year);
        }

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
    }
}
