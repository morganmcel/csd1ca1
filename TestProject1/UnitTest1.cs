using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var TestBP = new BPCalculator.BloodPressure { Systolic = 80, Diastolic = 40 };
            Assert.AreEqual(TestBP.Category, BPCalculator.BPCategory.Low);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var TestBP = new BPCalculator.BloodPressure { Systolic = 140, Diastolic = 90 };
            Assert.AreEqual(TestBP.Category, BPCalculator.BPCategory.High);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var TestBP = new BPCalculator.BloodPressure { Systolic = 110, Diastolic = 70 };
            Assert.AreEqual(TestBP.Category, BPCalculator.BPCategory.Ideal);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var TestBP = new BPCalculator.BloodPressure { Systolic = 130, Diastolic = 80 };
            Assert.AreEqual(TestBP.Category, BPCalculator.BPCategory.PreHigh);
        }
    }
}
