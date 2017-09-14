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
using System.Windows.Data;

namespace ExerciseManager.ViewModel
{
    public class AllLiftsViewModel : ViewModelBase
    {
        private string allliftfilter;
        public string AllLiftFilter
        {
            get { return allliftfilter; }
            set
            {
                allliftfilter = value;
                // NotifyPropertyChanged("AllLiftFilter");
                allliftview.Refresh();
            }
        }

        private LiftingItem liftingitem;
        public LiftingItem LiftingItem
        {
            get { return liftingitem; }
            set
            {
                liftingitem = value;
                // NotifyPropertyChanged("LiftingItem");
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
                // NotifyPropertyChanged("LiftingManager");
                // NotifyPropertyChanged("AllLifts");
            }
        }

        private ICollectionView allliftview;
        public ICollectionView AllLiftView
        {
            get { return allliftview; }
        }
        
        public ObservableCollection<LiftingItem> AllLifts { get; set; }        

        public AllLiftsViewModel()
        {

        }

        public void LoadAllLifts()
        {
            allliftview = (CollectionView)CollectionViewSource.GetDefaultView(AllLifts);
            allliftview.Filter = LiftFilter;
            // RaisePropertyChanged("AllLiftView");
        }

        public bool LiftFilter(object liftitem)
        {
            LiftingItem lift = liftitem as LiftingItem;
            return SearchLifts(lift, AllLiftFilter);
        }

        private bool SearchLifts(LiftingItem lift, string searchstring)
        {
            if (!string.IsNullOrEmpty(searchstring))
            {
                if (lift.Lift.Name.Trim().IndexOf(searchstring.Trim(), 0, StringComparison.OrdinalIgnoreCase) != -1)
                    return true;

            }
            else
            {
                return true;
            }

            return false;
        }

        // public event PropertyChangedEventHandler PropertyChanged;
        // 
        // public void NotifyPropertyChanged(string propertyname)
        // {
        //     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        // }
    }
}
