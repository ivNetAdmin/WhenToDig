using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WhenToDig.Models;

namespace WhenToDig.ViewModels
{
    public class ReviewContentFrostViewModel : BaseModel
    {
        public ReviewContentFrostViewModel()
        {
            var frosts = new List<Frost>(GetFrosts());
            var months = new int[12];

            var eariestMonth = 0;
            var latestMonth = 0;
            foreach (var frost in frosts)
            {
                var frostMonth = frost.Date.Month;

                if (frosts.IndexOf(frost) == 0)
                {
                    eariestMonth = latestMonth = frostMonth;
                    EariestMonthYear = LatestMonthYear = frost.Date.Year;
                }

                

                if (eariestMonth > frostMonth)
                {
                    eariestMonth = frostMonth;
                    EariestMonthYear = frost.Date.Year;
                }

                months[frostMonth - 1] = months[frostMonth - 1] + 1;
            }

            Months = new ObservableCollection<int>(months);
        }

        #region Properties
        private int _eariestMonthYear;
        public int EariestMonthYear
        {
            get { return _eariestMonthYear; }
            set
            {
                _eariestMonthYear = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }

        private int _latestMonthYear;
        public int LatestMonthYear
        {
            get { return _latestMonthYear; }
            set
            {
                _latestMonthYear = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }


        #region Properties
        private ObservableCollection<int> _listOfMonths;
        public ObservableCollection<int> Months
        {
            get { return _listOfMonths; }
            set
            {
                _listOfMonths = value;
                OnPropertyChanged(); // Added the OnPropertyChanged Method
            }
        }
        #endregion
        #endregion
    }
}
