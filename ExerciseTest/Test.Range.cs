using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExerciseManager.Models;

namespace ExerciseTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void InitalizeRangeMinMax()
        {
            Range newRange = new Range(3, 5);
            Assert.AreEqual(newRange.Min, 3);
            Assert.AreEqual(newRange.Max, 5);
        }

        [TestMethod]
        public void InitalizeRangeArray()
        {
            Range newRange = new Range(3, 5);
            int[] myarray = new int[] { 3, 4, 5 };

            CollectionAssert.AreEqual(newRange.RangeArray, myarray);            
        }

        [TestMethod]
        public void InitalizeRangeArrayOneElement()
        {
            Range newRange = new Range(3);
            int[] myarray = new int[] { 3 };

            CollectionAssert.AreEqual(newRange.RangeArray, myarray);
            Assert.AreEqual(newRange.Min, 3);
            Assert.AreEqual(newRange.Max, 3);
        }

        [TestMethod]
        public void TestSetRepsStringOneRep()
        {

            Range newRange = new Range(3);
            int[] myarray = new int[] { 3 };

            CollectionAssert.AreEqual(newRange.RangeArray, myarray);
            Assert.AreEqual(newRange.Min, 3);
            Assert.AreEqual(newRange.Max, 3);
        }
    }
}
