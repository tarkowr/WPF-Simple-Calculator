using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SimpleCalculator.Calculations
{
    public struct CalculateSideC : ITrigCalculate
    {
        public string Formula { get; set; }
        public Sides SideToFind { get; set; }

        /// <summary>
        /// Set Properties and Calculate the Third Side
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public double Calculate(double a, double b)
        {
            Formula = "C^2 = A^2 + B^2";
            SideToFind = Sides.C;
            return Math.Pow(a, 2) + Math.Pow(b, 2);
        }

        /// <summary>
        /// Determine if user input is valid for this formula
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidInput(double a, double b, out string message)
        {
            message = "";
            return true;
        }
    }
}
