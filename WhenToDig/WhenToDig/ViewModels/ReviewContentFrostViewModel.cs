using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WhenToDig.Helpers;
using WhenToDig.Models;

namespace WhenToDig.ViewModels
{
    public class ReviewContentFrostViewModel : BaseModel
    {
        public ReviewContentFrostViewModel()
        {  
            var frosts = new List<Frost>(GetFrosts());
            ProcessFrostData(frosts);           
        }
     
        #region Properties

        private DateTimeOffset _earliestFrost;
        public DateTimeOffset EarliestFrost
        {
            get { return _earliestFrost; }
            set
            {
                _earliestFrost = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }

        private DateTimeOffset _latestFrost;
        public DateTimeOffset LatestFrost
        {
            get { return _latestFrost; }
            set
            {
                _latestFrost = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }

        private ObservableCollection<FrostCount> _listOfMonths;
        public ObservableCollection<FrostCount> Months
        {
            get { return _listOfMonths; }
            set
            {
                _listOfMonths = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }

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

        private string _year;
        public string Year
        {
            get { return _year; }
            set
            {
                _year = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }

        private string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }
        #endregion

        private void ProcessFrostData(List<Frost> frosts)
        {
            var monthNames = new string[12] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            var months = new int[12];
            var firstYear = 0;
            var lastYear = 0;
            var earliestFrost = new DateTimeOffset();
            var latestFrost = new DateTimeOffset();
            var years = new List<string>();
            var maxFrostCount = 0;

            foreach (var frost in frosts)
            {
                var yearSplitDate = new DateTimeOffset(new DateTime(frost.Date.Year, 8, 1));
                var frostDate = frost.Date;

                #region set variables first time around
                if (frosts.IndexOf(frost) == 0)
                {
                    earliestFrost = frost.Date.Date;
                    firstYear = lastYear = frost.Date.Year;
                }
                #endregion

                #region  determine first and last frost dates
                if (frostDate > yearSplitDate)
                {
                    // earliest frost
                    if (frostDate.Date
                        <= new DateTimeOffset(new DateTime(frost.Date.Year, earliestFrost.Month, earliestFrost.Day)))
                    {
                        earliestFrost = frost.Date;
                    }
                }
                else
                {
                    // latest frost
                    if (frostDate.Date
                        >= new DateTimeOffset(new DateTime(frost.Date.Year, latestFrost.Month, latestFrost.Day)))
                    {
                        latestFrost = frost.Date;
                    }
                }
                #endregion

                #region determine date range
                if (frostDate.Year > lastYear) lastYear = frostDate.Year;
                if (frostDate.Year < firstYear) firstYear = frostDate.Year;
                #endregion

                months[frost.Date.Month - 1] = months[frost.Date.Month - 1] + 1;
            }

            years.Add("All");
            for (int i = firstYear; i <= lastYear; i++)
            {
                years.Add(i.ToString());
            }

            var frostCounts = new List<FrostCount>();
            for (int i = earliestFrost.Date.Month - 1; i < 12; i++)
            {
                frostCounts.Add(new FrostCount { Month = monthNames[i], Count = months[i] });
                if (maxFrostCount < months[i]) maxFrostCount = months[i];
            }
            for (int i = 0; i < latestFrost.Date.Month; i++)
            {
                frostCounts.Add(new FrostCount { Month = monthNames[i], Count = months[i] });
                if (maxFrostCount < months[i]) maxFrostCount = months[i];
            }

            foreach(var frostCount in frostCounts)
            {
                frostCount.MaxFrostCount = maxFrostCount+2;
            }

            #region initialise view
            Months = new ObservableCollection<FrostCount>(frostCounts);
            Years = new ObservableCollection<string>(years);
            EarliestFrost = earliestFrost;
            LatestFrost = latestFrost;
            #endregion
        }

    }

}
