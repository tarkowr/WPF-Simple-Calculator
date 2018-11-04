using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SimpleCalculator.Calculations
{
    public struct CalculateSideA : ITrigCalculate
    {
        public string Formula { get; set; }
        public Sides SideToFind { get; set; }

        /// <summary>
        /// Set Properties and Calculate the Third Side
        /// </summary>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public double Calculate(double b, double c)
        {
            Formula = "A^2 = C^2 - B^2";
            SideToFind = Sides.A;
            return Math.Pow(c, 2) - Math.Pow(b, 2);
        }

        /// <summary>
        /// Determine if user input is valid for this formula
        /// </summary>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidInput(double b, double c, out string message)
        {
            message = "";

            if (b >= c)
            {
                message = "B can not be greater than or equal to C.";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
