using System;
using NUnit.Framework;

namespace Gamesys.Solutions.Test
{
    [TestFixture]
    [Description("Arithmetic Test")]
    public class ArithmeticTest
    {
        [Test]
        public void PlusTest()
        {
            var expectedValue = 3;
            var returned = 1d.Plus(2);

            Assert.AreEqual(expectedValue, returned);
        }

        [Test]
        public void MinusTest()
        {
            var expectedValue = 1;
            var returned = 3d.Minus(2);

            Assert.AreEqual(expectedValue, returned);
        }

        [Test]
        [TestCase(4, 2, 2)]
        [TestCase(4, 1, 4)]
        [TestCase(4, 0, 0)]
        [TestCase(0, 4, 0)]
        public void DivideTest(double value, double action, double expected)
        {
            var returned = value.Divide(action);
            Assert.AreEqual(expected, returned);
        }
        
        [Test]
        [TestCase(2, 0, 1)]
        [TestCase(2, 1, 2)]
        [TestCase(2, 2, 4)]
        [TestCase(2, 3, 8)]
        public void PowTest(double value, double action, double expected)
        {
            var returned = value.Pow(action);
            Assert.AreEqual(expected, returned);
        }

        [Test]
        [TestCase(2, 50, 1)]
        [TestCase(100, 5, 5)]
        [TestCase(0, 50, 0)]
        [TestCase(2, 0, 2)]
        [TestCase(50, 16, 8)]
        public void PercentOfTest(double value, double action, double expected)
        {
            var returned = value.PercentOf(action);
            Assert.AreEqual(expected, returned);
        }

        
        [Test]
        [TestCase(0.75, 0.75)]
        [TestCase(0.65, 0.75)]
        [TestCase(0.99, 1)]
        [TestCase(0.16, 0.25)]
        public void RoundNearestQuaterTest(double value, double expected)
        {
            var returned = value.RoundNearestQuater();
            Assert.AreEqual(expected, returned);
        }
    }
}
