using ExerciseManager.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace ExerciseManager.ViewModel
{
    public class AllLiftsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private LiftingItem liftingitem;
        public LiftingItem LiftingItem
        {
            get { return liftingitem; }
            set
            {
                liftingitem = value;
                NotifyPropertyChanged("LiftingItem");
            }
        }

        private LiftingManager liftingmanager;
        public LiftingManager LiftingManager
        {
            get { return liftingmanager; }
            set
            {
                liftingmanager = value;
                AllLifts = liftingmanager.ListAllLifts();
                NotifyPropertyChanged("LiftingManager");
                NotifyPropertyChanged("AllLifts");
            }
        }
        
        public ObservableCollection<LiftingItem> AllLifts { get; set; }        

        public AllLiftsViewModel()
        {            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
