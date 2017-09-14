using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Web.Script.Serialization;


namespace ExerciseManager.Models
{
    public class LiftingManager
    {
        private const string DEFAULT_FILENAME = "workout.json";

        public ObservableCollection<LiftingRoutine> Routines { get; set; } = new ObservableCollection<LiftingRoutine>();        

        public void Save(string filename = DEFAULT_FILENAME)
        {
            File.WriteAllText(filename, (new JavaScriptSerializer()).Serialize(this));
        }

        public void Load(string filename = DEFAULT_FILENAME)
        {
            LiftingManager lm = new LiftingManager();
            if (File.Exists(filename))
                lm = (new JavaScriptSerializer()).Deserialize<LiftingManager>(File.ReadAllText(filename));

            Routines = lm.Routines;
        }

        public ObservableCollection<LiftingItem> ListAllLifts()
        {
            ObservableCollection<LiftingItem> listofliftingitems = new ObservableCollection<LiftingItem>();
            foreach(LiftingRoutine lr in Routines)
            {
                foreach (LiftingItem li in lr.LiftingItems)
                    listofliftingitems.Add(li);
            }

            return listofliftingitems;
        }            
    }
}
