using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseManager.Models
{

    public enum WeightType
    {
        Static,

        Percent
    }

    public class Weight : INotifyPropertyChanged
    {
        private WeightType weighttype;
        public WeightType WeightType
        {
            get { return weighttype; }
            set
            {
                weighttype = value;
                NotifyPropertyChanged("WeightType");
            }
        }

        private double amount;
        public double Amount
        {
            get
            {
                if(WeightType == WeightType.Static)
                    return amount;
                if (WeightType == WeightType.Percent &&
                    BasedOnThisLift != null)
                {
                    return Math.Round(BasedOnThisLift.Weight.Amount * percent);
                }
                else
                    return amount;
            }
            set
            {
                amount = value;
                NotifyPropertyChanged("Amount");
            }
        }

        private double percent;
        public double Percent
        {
            get { return percent * 100; }
            set
            {
                percent = value;
                NotifyPropertyChanged("Amount");
                NotifyPropertyChanged("Percent");
            }
        }

        public Weight()
        {
        }

        public Weight(double inAmount)
        {
            Amount = inAmount;
            WeightType = WeightType.Static;
        }

        public Weight(double inPercent, LiftingItem basedOn)
        {
            Percent = inPercent * .01;
            WeightType = WeightType.Percent;
            BasedOnThisLift = basedOn;
        }


        private LiftingItem basedonthislift;
        public LiftingItem BasedOnThisLift
        {
            get { return basedonthislift; }
            set
            {
                basedonthislift = value;
                NotifyPropertyChanged("BasedOnThisLift");
                NotifyPropertyChanged("Amount");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
