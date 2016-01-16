using System;
using System.Collections.Generic;
using System.Linq;

namespace Gamesys.Solutions
{
    public class Solution
    {
        public double GetFirstNumber(double x)
        {
            return 0.5.Multiple(x.Pow(2)).Plus(x.Multiple(30)).Plus(10).Divide(25);
        }

        public double GetGrowthRate(double y, double firstNumber)
        {
            return y.PercentOf(2).Divide(25).Divide(firstNumber);
        }

        public IEnumerable<double> GetSeries(double firstNumber, double growthRate, int length)
        {
            var series = new List<double>();

            for (var index = 0; index < length; index++)
            {
                var value = growthRate.Multiple(firstNumber.Pow(index)).RoundNearestQuater();
                series.Add(value);
            }
            series.Sort();
            return series;
        }

        public double GetThirdLargestNumber(List<double> series)
        {
            if (series.Count() < 3)
                return -1;

            var index = Math.Abs(3 - series.Count());
            return series[index];
        }

        public double GetApproximateNumber(List<double> series, double z)
        {
            var approximateNumber = 1000.0.Divide(z);
            var index = Array.BinarySearch<double>(series.ToArray(), approximateNumber);
            if (index >= 0) return series[index];

            index = ~index;
            if (index == series.Count())
            {
                index = index - 1;
            }
            else if (index == 0)
            {
                index = 0;
            }
            else if (Math.Abs(approximateNumber - series[index - 1]) <
                     Math.Abs(approximateNumber - series[index]))
            {
                index = index - 1;

            }
            return series[index];
        }
    }
}