namespace test
{
    public class NumberAverageTest
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void TestFindAverageSuccess()
        {
            string result = NumberAverage.NumberAverage.FindAverage(new int[] { 4, 5, 6 });
            Assert.AreEqual("The Average is: 5", result);
        }
        [Test]
        public void TestFindAverageWithNegative()
        {
            string result = NumberAverage.NumberAverage.FindAverage(new int[] { 4, -5, 6 });
            Assert.AreEqual("Negative values in array", result);
        }
        [Test]
        public void TestFindAverageEmptyArray()
        {
            string result = NumberAverage.NumberAverage.FindAverage(new int[] { });
            Assert.AreEqual("Array is Empty", result);
        }
    }
}