using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Gamesys.Solutions.Test
{
    [TestFixture]
    public class SolutionTest
    {
        private Solution _solution;
        
        [SetUp]
        public void Init()
        {
            _solution = new Solution();
        }

        [Test]
        [TestCase(1, 1.62)]
        [TestCase(2, 2.88)]
        [TestCase(3, 4.18)]
        public void GetFirstNumberTest(double value, double expected)
        {
            var returned = Math.Round(_solution.GetFirstNumber(value),2);

            Assert.AreEqual(expected, returned);
        }

        [Test]
        [TestCase(5062.5, 1.62, 2.5)]
        public void GetGrowthRateTest(double value, double firstNumber, double expected)
        {
            var returned = Math.Round(_solution.GetGrowthRate(value, firstNumber),1);

            Assert.AreEqual(expected, returned);
        }

        // The paper says the result will be {1.5, 4.0 ... } 
        // , but the first value 1.5 should be 2.5 as growthRate is 2.5
        public static List<List<double>> SourceSerieseLists()
        {
            var sourceSerieseLists = new List<List<double>>()
                                    {
                                      new List<double>() {2.5},
                                      new List<double>() {2.5, 4, 6.5},
                                      new List<double>() {2.5, 4, 6.5, 10.75},
                                      new List<double>() {2.5, 4, 6.5, 10.75, 17.25}
                                    };
            return sourceSerieseLists;
        }

        [Test]
        [TestCaseSource(nameof(SourceSerieseLists))]
        public void SerieseTest(List<double> expected)
        {
            var returned = _solution.GetSeries(1.62, 2.5, expected.Count);
            Assert.That(expected, Is.EquivalentTo(returned));
        }
        
        public static List<Tuple<List<double>, double>> SourceThirdLargestLists()
        {
            var sourceSerieseLists = SourceSerieseLists();
            var sourceThirdLargestLists = new List<Tuple<List<double>, double>>();

            var testCase1 = new Tuple<List<double>, double>(sourceSerieseLists[0], -1);
            sourceThirdLargestLists.Add(testCase1);
            var testCase2 = new Tuple<List<double>, double>(sourceSerieseLists[1], 2.5);
            sourceThirdLargestLists.Add(testCase2);
            var testCase3 = new Tuple<List<double>, double>(sourceSerieseLists[2], 4);
            sourceThirdLargestLists.Add(testCase3);
            var testCase4 = new Tuple<List<double>, double>(sourceSerieseLists[3], 6.5);
            sourceThirdLargestLists.Add(testCase4);

            return sourceThirdLargestLists;
        }

        [Test]
        [TestCaseSource(nameof(SourceThirdLargestLists))]
        public void ThirdLargestNumberTest(Tuple<List<double>, double> testCase)
        {
            var returned = _solution.GetThirdLargestNumber(testCase.Item1);

            Assert.AreEqual(testCase.Item2, returned);
        }

        [Test]
        [TestCase(250, 4)]
        [TestCase(200, 4)]
        [TestCase(160, 6.5)]
        [TestCase(100, 10.75)]
        [TestCase(50, 17.25)]
        [TestCase(1, 17.25)]
        public void ApproximateNumberTest(double x, double expected)
        {
            var series = new List<double>() {2.5, 4, 6.5, 10.75, 17.25};

            var returned = _solution.GetApproximateNumber(series,x);

            Assert.AreEqual(expected, returned);
        }
    }
}
