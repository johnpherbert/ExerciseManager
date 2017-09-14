using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseManager.Models
{    
    public enum LiftFrequency
    {
        DaysOfWeek,
        DaysInBetween
    };

    public class LiftingRoutine : INotifyPropertyChanged
    {
        public static string[] daysoftheweek = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public string[] DaysOfTheWeek
        {
            get { return daysoftheweek; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string dayofweek;
        public string DayOfWeek
        {
            get { return dayofweek; }
            set
            {
                dayofweek = value;
                NotifyPropertyChanged("DayOfWeek");
            }
        }

        private int frequency;
        public int Frequency
        {
            get { return frequency; }
            set
            {
                frequency = value;
                NotifyPropertyChanged("Frequency");
            }
        }


        public ObservableCollection<LiftingItem> LiftingItems { get; set; } = new ObservableCollection<LiftingItem>();

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
