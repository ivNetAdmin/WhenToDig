using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WhenToDig.Helpers;
using WhenToDig.Models;

namespace WhenToDig.ViewModels
{
    public class ReviewContentJobViewModel : BaseModel
    {
        public ReviewContentJobViewModel()
        {
            GetYearList();
            Title = "Job Review";
        }

        #region Properties
        private ObservableCollection<string> _listOfYears;
        public ObservableCollection<string> Years
        {
            get { return _listOfYears; }
            set
            {
                _listOfYears = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }

        private ObservableCollection<JobTypeCount> _jobTypeCounts;
        public ObservableCollection<JobTypeCount> JobTypeCounts
        {
            get { return _jobTypeCounts; }
            set
            {
                _jobTypeCounts = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }
        private string _year;
        public string Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
                ProcessJobData();
            }
        }       
        #endregion

        #region Private Methods
        private void GetYearList()
        {
            var years = new List<string> { "All" };
            var jobs = new List<Job>(GetJobs("All"));
            foreach (var job in jobs)
            {
                if(jobs.IndexOf(job)==0)
                {
                    var startYear = string.Format("{0}/{1}", job.Date.Year - 1, job.Date.Year);
                    if (!years.Contains(startYear))
                    {
                        years.Add(startYear);
                    }
                }
                var year = string.Format("{0}/{1}", job.Date.Year, job.Date.Year + 1);
                if (!years.Contains(year))
                {
                    years.Add(year);
                }
            }

            Years = new ObservableCollection<string>(years);
        }

        private void ProcessJobData()
        {
            var jobs = new List<Job>(GetJobs(_year));
            var cultivate = 0;
            var preparation = 0;
            var general = 0;
            foreach (var job in jobs)
            {
                switch (job.Type)
                {
                    case "Cultivate":
                        cultivate++;
                        break;
                    case "Preparation":
                        preparation++;
                        break;
                    case "General":
                        general++;
                        break;
                }
            }

            JobTypeCounts = new ObservableCollection<JobTypeCount>(new List<JobTypeCount> {
                new JobTypeCount { Name = "Cultivate", Count = cultivate==0?1:Convert.ToInt32((cultivate/jobs.Count)*100) },
                new JobTypeCount { Name = "Preparation", Count = preparation==0?1:Convert.ToInt32((preparation/jobs.Count)*100) },
                new JobTypeCount { Name = "General", Count = general==0?1:Convert.ToInt32((general/jobs.Count)*100) }
            });
        }

        #endregion
    }


}
