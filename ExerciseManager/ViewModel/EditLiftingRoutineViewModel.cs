using ExerciseManager.Models;
using ExerciseManager.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExerciseManager.ViewModel
{
    public class EditLiftingRoutineViewModel : ViewModelBase
    {
        public LiftingManager LiftingManager { get; set; }

        public LiftingRoutine LiftingRoutine { get; set; }

        public ICommand BasedOnAmountCommand { get; private set; }        

        public EditLiftingRoutineViewModel()
        {
            BasedOnAmountCommand = new RelayCommand<LiftingItem>((liftingitem) => BasedOnAmount(liftingitem));            
        }

        public void BasedOnAmount(LiftingItem liftingitem)
        {
            var allliftsvm = SimpleIoc.Default.GetInstance<AllLiftsViewModel>();
            allliftsvm.LiftingItem = liftingitem;
            allliftsvm.LiftingManager = LiftingManager;

            var allliftsview = new AllLiftsView()
            {
                DataContext = allliftsvm
            };

            allliftsview.ShowDialog();
        }
    }
}
