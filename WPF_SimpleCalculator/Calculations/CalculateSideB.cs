using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SimpleCalculator.Calculations
{
    public struct CalculateSideB : ITrigCalculate
    {
        public string Formula { get; set; }
        public Sides SideToFind { get; set; }

        /// <summary>
        /// Set Properties and Calculate the Third Side
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public double Calculate(double a, double c)
        {
            Formula = "B^2 = C^2 - A^2";
            SideToFind = Sides.B;
            return Math.Pow(c, 2) - Math.Pow(a, 2);
        }

        /// <summary>
        /// Determine if user input is valid for this formula
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidInput(double a, double c, out string message)
        {
            message = "";

            if (a >= c)
            {
                message = "A can not be greater than or equal to C.";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
