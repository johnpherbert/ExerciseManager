using ExerciseManager.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using GalaSoft.MvvmLight.Ioc;
using ExerciseManager.View;


namespace ExerciseManager.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public LiftingManager LiftingManager { get; set; } = new LiftingManager();


        #region Commands

        public ICommand CreateNewRoutineCommand { get; private set; }

        public ICommand DeleteRoutineCommand { get; private set; }

        public ICommand CreateNewLiftingItemCommand { get; private set; }

        public ICommand DeleteLiftingItemCommand { get; private set; }

        public ICommand EditLiftingItemCommand { get; private set; }
       
        #endregion

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            CreateNewRoutineCommand = new RelayCommand(() => CreateRoutine());
            DeleteRoutineCommand = new RelayCommand<LiftingRoutine>((routine) => DeleteRoutine(routine));
            CreateNewLiftingItemCommand = new RelayCommand<LiftingRoutine>((routine) => CreateNewLiftingItem(routine));
            DeleteLiftingItemCommand = new RelayCommand<LiftingItem>((liftingitem) => DeleteLiftingItem(liftingitem));
            EditLiftingItemCommand = new RelayCommand<LiftingRoutine>((liftingroutine) => EditLiftingItem(liftingroutine));

            LiftingRoutine lr = new LiftingRoutine();
            lr.DayOfWeek = "Monday";
            lr.Name = "Power Upper";

            lr.LiftingItems.Add(new LiftingItem(new Lift("Bent Over Row"), 3, new Range(3, 5), new Weight(90), "Power", "Pull"));
            lr.LiftingItems.Add(new LiftingItem(new Lift("Pullups"), 2, new Range(6, 10), new Weight(0), "Assistance", "Pull"));
            lr.LiftingItems.Add(new LiftingItem(new Lift("Rack chins"), 2, new Range(6, 10), new Weight(0), "Auxiliary", "Pull"));

            lr.LiftingItems.Add(new LiftingItem(new Lift("Benchpress"), 3, new Range(3, 5), new Weight(110), "Power", "Press"));
            lr.LiftingItems.Add(new LiftingItem(new Lift("Dips"), 2, new Range(6, 10), new Weight(0), "Assistance", "Press"));
            lr.LiftingItems.Add(new LiftingItem(new Lift("Overhead Press"), 2, new Range(6, 10), new Weight(60), "Assistance", "Press"));

            lr.LiftingItems.Add(new LiftingItem(new Lift("Barbell Curls"), 3, new Range(6, 10), new Weight(15), "Auxiliary", "Curling"));
            lr.LiftingItems.Add(new LiftingItem(new Lift("Skull Crushers"), 3, new Range(6, 10), new Weight(15), "Auxiliary", "Extension"));

            LiftingManager.Routines.Add(lr);

            LiftingRoutine lr2 = new LiftingRoutine();
            lr2.DayOfWeek = "Tuesday";
            lr2.Name = "Power Lower";

            lr2.LiftingItems.Add(new LiftingItem(new Lift("Squats"), 3, new Range(3, 5), new Weight(90), "Power", "Press"));
            lr2.LiftingItems.Add(new LiftingItem(new Lift("Hack Squat"), 2, new Range(6, 10), new Weight(0), "Assistance", "Press"));
            lr2.LiftingItems.Add(new LiftingItem(new Lift("Leg Extensions"), 2, new Range(6, 10), new Weight(0), "Assistance", "Extension"));

            lr2.LiftingItems.Add(new LiftingItem(new Lift("Deadlift"), 3, new Range(5, 8), new Weight(110), "Assistance", "Pull"));
            lr2.LiftingItems.Add(new LiftingItem(new Lift("Glute Ham Raises"), 2, new Range(6, 10), new Weight(0), "Assistance", "Pull/Curl"));

            lr2.LiftingItems.Add(new LiftingItem(new Lift("Standing Calf Raises"), 3, new Range(6, 10), new Weight(15), "Auxiliary", "Calf"));
            lr2.LiftingItems.Add(new LiftingItem(new Lift("Seated Calf Raises"), 2, new Range(6, 10), new Weight(15), "Auxiliary", "Calf"));

            LiftingManager.Routines.Add(lr2);

            LiftingRoutine lr3 = new LiftingRoutine();
            lr3.DayOfWeek = "Thursday";
            lr3.Name = "Back and Shoulders Hypertrophy Day";

            lr3.LiftingItems.Add(new LiftingItem(new Lift("Bent Over Row"), 6, new Range(3, 5), new Weight(70,lr.LiftingItems[0]), "Power", "Pull"));
            lr3.LiftingItems.Add(new LiftingItem(new Lift("Rack Chin"), 3, new Range(6, 12), new Weight(0), "Hypertrophy", "Pull"));
            lr3.LiftingItems.Add(new LiftingItem(new Lift("Cable Row"), 3, new Range(8, 12), new Weight(0), "Hypertrophy", "Pull"));
            lr3.LiftingItems.Add(new LiftingItem(new Lift("Dumbell Row"), 2, new Range(12, 15), new Weight(110), "Hypertrophy", "Pull"));        
            lr3.LiftingItems.Add(new LiftingItem(new Lift("Close Grip Pulldown"), 2, new Range(15, 20), new Weight(0), "Hypertrophy", "Pull"));

            lr3.LiftingItems.Add(new LiftingItem(new Lift("Seated Dumbell Press"), 3, new Range(8, 12), new Weight(15), "Hypertrophy", "Shoulder"));
            lr3.LiftingItems.Add(new LiftingItem(new Lift("Upright Row"), 2, new Range(12, 15), new Weight(15), "Hypertrophy", "Shoulder"));
            lr3.LiftingItems.Add(new LiftingItem(new Lift("Side Lateral Raise"), 3, new Range(12, 20), new Weight(15), "Hypertrophy", "Shoulder"));

            LiftingManager.Routines.Add(lr3);

            LiftingRoutine lr4 = new LiftingRoutine();
            lr4.DayOfWeek = "Friday";
            lr4.Name = "Lower Body Hypertrophy Day";

            lr4.LiftingItems.Add(new LiftingItem(new Lift("Squats"), 6, new Range(3, 5), new Weight(70, lr.LiftingItems[0]), "Power", "Press"));
            lr4.LiftingItems.Add(new LiftingItem(new Lift("Hack Squats"), 3, new Range(8, 12), new Weight(0), "Hypertrophy", "Press"));
            lr4.LiftingItems.Add(new LiftingItem(new Lift("Leg Presses"), 2, new Range(12, 15), new Weight(0), "Hypertrophy", "Press"));
            lr4.LiftingItems.Add(new LiftingItem(new Lift("Leg Extensions"), 3, new Range(15, 20), new Weight(110), "Hypertrophy", "Extension"));
            lr4.LiftingItems.Add(new LiftingItem(new Lift("Romanian Deadlifts"), 2, new Range(12, 15), new Weight(0), "Hypertrophy", "Pulling"));

            lr4.LiftingItems.Add(new LiftingItem(new Lift("Lying Leg Curls"), 2, new Range(12, 15), new Weight(15), "Hypertrophy", "Curling"));
            lr4.LiftingItems.Add(new LiftingItem(new Lift("Seated Leg Curls"), 2, new Range(15, 20), new Weight(15), "Hypertrophy", "Curling"));

            lr4.LiftingItems.Add(new LiftingItem(new Lift("Donkey Calf Raises"), 4, new Range(10, 15), new Weight(15), "Hypertrophy", "Calf"));
            lr4.LiftingItems.Add(new LiftingItem(new Lift("Seated Calf Raises"), 3, new Range(15, 20), new Weight(15), "Hypertrophy", "Calf"));

            LiftingManager.Routines.Add(lr4);


            // LiftingRoutine lr2 = new LiftingRoutine();
            // 
            // LiftingItem li2 = new LiftingItem
            // {
            //     CategoryLift = CategoryLift.Main,
            //     Lift = new Lift() { Name = "Deadlift" },
            //     Reps = new Range(5),
            //     Sets = 5,
            //     PushPullLift = PushPullLift.Push,
            //     TypeOfLift = TypeOfLift.Power,
            //     Weight = 110
            // };
            // 
            // lr2.DayOfWeek = "Tuesday";
            // lr2.LiftingItems.Add(li2);
            // 
            // LiftingManager.Routines.Add(lr2);
        }

        private void DeleteLiftingItem(LiftingItem liftingitem)
        {

        }

        private void EditLiftingItem(LiftingRoutine liftingroutine)
        {
            var editroutinevm = SimpleIoc.Default.GetInstance<EditLiftingRoutineViewModel>();
            editroutinevm.LiftingRoutine = liftingroutine;
            editroutinevm.LiftingManager = LiftingManager;

            var editroutineview = new EditLiftingRoutineView()
            {
                DataContext = editroutinevm
            };

            editroutineview.ShowDialog();
        }

        private void CreateNewLiftingItem(LiftingRoutine routine)
        {
            if (routine != null)
                routine.LiftingItems.Add(new LiftingItem());
        }

        private void DeleteRoutine(LiftingRoutine routine)
        {
            if (routine != null)
                LiftingManager.Routines.Remove(routine);
        }

        private void CreateRoutine()
        {
            LiftingManager.Routines.Add(new LiftingRoutine());
        }
    }
}