using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExerciseManager.Models
{
    public class LiftingItem : INotifyPropertyChanged
    {
        public static string[] pushpulllifts = new string[] { "Press", "Pull", "Curling", "Extension", "Calf" };
        public string[] PushPullLifts
        {
            get { return pushpulllifts; }
        }

        public static string[] typeoflifts = new string[] { "Power", "Hypertrophy", "Assistance", "Auxiliary" };
        public string[] TypeOfLifts
        {
            get { return typeoflifts; }
        }

        private Lift lift;
        public Lift Lift
        {
            get { return lift; }
            set
            {
                lift = value;
                NotifyPropertyChanged("Lift");
            }
        }

        private int sets;
        public int Sets
        {
            get { return sets; }
            set
            {
                sets = value;
                NotifyPropertyChanged("Sets");
            }
        }

        private Range reps;
        public Range Reps
        {
            get { return reps; }
            set
            {
                reps = value;
                NotifyPropertyChanged("Reps");
            }
        }

        public string RepSetDescription
        {
            get
            {
                return FormatRepSetString();
            }
            set
            {
                SetRepSetsFromString(value);
            }
        }

        private string typeoflift;
        public string TypeOfLift
        {
            get { return typeoflift; }
            set
            {
                typeoflift = value;
                NotifyPropertyChanged("TypeOfLift");
            }
        }

        private string pushpulllift;
        public string PushPullLift
        {
            get { return pushpulllift; }
            set
            {
                pushpulllift = value;
                NotifyPropertyChanged("PushPullLift");
            }
        }

        private Weight weight;
        public Weight Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                NotifyPropertyChanged("Weight");
            }
        }

        public LiftingItem()
        {
        }

        public LiftingItem(Lift inLift, int inSets, Range inReps, Weight inWeight, string tol, string ppl)
        {
            Lift = inLift;
            Sets = inSets;
            Reps = inReps;
            Weight = inWeight;
            TypeOfLift = tol;
            PushPullLift = ppl;            
        }

        private string FormatRepSetString()
        {
            string returnString = string.Empty;

            if (Reps != null && Reps.Count != 0)
            {
                if (Reps.Count == 1)
                    returnString = $"{Sets} x {Reps.Min}";
                else
                    returnString = $"{Sets} x {Reps.Min}-{Reps.Max}";
            }

            return returnString;
        }

        internal void SetRepSetsFromString(string repsetstring)
        {
            // Group 1 is Sets
            // Group 2 is Rep Min
            // Group 4 is Rep Max
            Regex repsetregex = new Regex(@"^\s*([0-9]+)\s*x\s*([0-9]+)\s*(-\s*([0-9]+))?\s*$");
            if(repsetregex.IsMatch(repsetstring))
            {
                Match repsetmatch = repsetregex.Match(repsetstring);

                // Group 1 is the number of sets
                bool validsets = false;
                if (int.TryParse(repsetmatch.Groups[1].Value, out int setsparse))                                    
                    validsets = true;                

                // Group 2 is either the number of reps or the min rep value
                bool validminrep = false;
                if(int.TryParse(repsetmatch.Groups[2].Value, out int repminparse))                                    
                    validminrep = true;                

                // Group 4 may not exist.  If it does its the rep max value
                if (int.TryParse(repsetmatch.Groups[4].Value, out int repmaxparse) && validminrep && validsets)
                {                    
                    // If we have valid sets and valid min rep we will set the values.
                    Sets = setsparse;
                    Reps = new Range(repminparse, repmaxparse);
                }
                else if(validminrep && validsets)
                {
                    // We didnt have a max set or it was not valid so we will just set min rep and sets
                    Sets = setsparse;
                    Reps = new Range(repminparse);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
