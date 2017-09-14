using ExerciseManager.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTest
{
    [TestClass]
    public class TestLiftingItem
    {
        [TestMethod]
        public void LiftingItemSetRepDescriptionOneRep()
        {
            LiftingItem li = new LiftingItem()
            {
                Reps = new Range(5),
                Sets = 3
            };

            string description = li.RepSetDescription;

           Assert.AreEqual("3 x 5", description);
        }

        [TestMethod]
        public void LiftingItemSetRepDescriptionMultipleRep()
        {
            LiftingItem li = new LiftingItem()
            {
                Reps = new Range(5,8),
                Sets = 3
            };

            string description = li.RepSetDescription;

            Assert.AreEqual("3 x 5-8", description);
        }

        [TestMethod]
        public void ParseSetRepStrings()
        {
            LiftingItem li = new LiftingItem();            
            li.RepSetDescription = "3x5";            

            Assert.AreEqual("3 x 5", li.RepSetDescription);

            li.RepSetDescription = " 3x5";

            Assert.AreEqual("3 x 5", li.RepSetDescription);

            li.RepSetDescription = " 3 x5";

            Assert.AreEqual("3 x 5", li.RepSetDescription);

            li.RepSetDescription = " 3 x 5";

            Assert.AreEqual("3 x 5", li.RepSetDescription);

            li.RepSetDescription = " 3 x 5 ";

            Assert.AreEqual("3 x 5", li.RepSetDescription);

            li.RepSetDescription = "3x5-6";

            Assert.AreEqual("3 x 5-6", li.RepSetDescription);

            li.RepSetDescription = " 3x5-6";

            Assert.AreEqual("3 x 5-6", li.RepSetDescription);

            li.RepSetDescription = " 3 x5-6";

            Assert.AreEqual("3 x 5-6", li.RepSetDescription);

            li.RepSetDescription = " 3 x 5-6";

            Assert.AreEqual("3 x 5-6", li.RepSetDescription);

            li.RepSetDescription = " 3 x 5 -6";

            Assert.AreEqual("3 x 5-6", li.RepSetDescription);

            li.RepSetDescription = " 3 x 5 - 6";

            Assert.AreEqual("3 x 5-6", li.RepSetDescription);

            li.RepSetDescription = " 3 x 5 - 6 ";

            Assert.AreEqual("3 x 5-6", li.RepSetDescription);

            li.RepSetDescription = " 31 x 52 - 65 ";

            Assert.AreEqual("31 x 52-65", li.RepSetDescription);
        }
    }
}
