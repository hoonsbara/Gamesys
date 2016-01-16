using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamesys.Solutions
{
    public static class Arithmetic
    {
        public static double Plus(this double value, double action)
        {
            return value + action;
        }
        public static double Minus(this double value, double action)
        {
            return value - action;
        }
        public static double Multiple(this double value, double action)
        {
            return value * action;
        }
        public static double Divide(this double value, double action)
        {
            if (CheckIfAnyZero(value, action))
                return 0;

            return value / action;
        }

        public static double Pow(this double value, double action)
        {
            return Math.Pow(value, action);
        }

        public static double PercentOf(this double value, double action)
        {
            if (CheckIfAnyZero(value, action))
                return value;

            double percent = action.Divide(100);
            return value.Multiple(percent);
        }

        public static double RoundNearestQuater(this double value)
        {
            return Math.Round(value * 4, MidpointRounding.ToEven) / 4;
        }
        
        private static bool CheckIfAnyZero(double value, double action)
        {
            return ((int) value == 0 || (int) action == 0);
        }
        
    }
}
