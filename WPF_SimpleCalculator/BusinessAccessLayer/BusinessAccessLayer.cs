using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_SimpleCalculator.Calculations;

namespace WPF_SimpleCalculator.BusinessAccessLayer
{
    public class BusinessLayer
    {
        ITrigCalculate _trigCalculate;
        public double maxValue = 1000000;

        /// <summary>
        /// Set the Trig Calculation Type
        /// </summary>
        /// <param name="AB"></param>
        /// <param name="AC"></param>
        /// <param name="BC"></param>
        internal void SetCalculationType(bool AB, bool AC, bool BC)
        {
            if (AB)
            {
                _trigCalculate = new CalculateSideC();
            }
            else if (AC)
            {
                _trigCalculate = new CalculateSideB();
            }
            else
            {
                _trigCalculate = new CalculateSideA();
            }
        }

        /// <summary>
        /// Validate A, B, C input
        /// </summary>
        /// <param name="value"></param>
        /// <param name="output"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        internal bool ValidateInput(string value, out double output, out string message)
        {
            message = "";

            if (double.TryParse(value, out output))
            {
                if (output > 0)
                {
                    if (output > maxValue)
                    {
                        message = $"must be less than or equal to 1M";
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    message = "must be greater than Zero.";
                    return false;
                }
            }
            else
            {
                message = "must be a number.";
                return false;
            }
        }

        /// <summary>
        /// Check if the Trig Function is valid with the input
        /// </summary>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        internal bool ValidTrigFunction(double val1, double val2, out string message)
        {
            bool validInput = false;
            message = "";

            if (_trigCalculate.ValidInput(val1, val2, out message))
            {
                validInput = true;
            }

            return validInput;
        }

        /// <summary>
        /// Calculate and Dsiplay the Solution
        /// </summary>
        /// <param name="displayFormula"></param>
        /// <param name="output"></param>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        internal void CalculateAndDisplayTrigAnswer(bool displayFormula, bool output, double val1, double val2)
        {
            double answer;
            string formula, answerContext;

            answer = CalculateAnswer(output, val1, val2);

            formula = BuildFormula(displayFormula);

            answerContext = BuildAnswerContext(output);

            SolutionWindow solutionForm = new SolutionWindow(new SolutionInfo(answer, formula, answerContext));
            solutionForm.ShowDialog();
        }

        /// <summary>
        /// Perform Math Operation to calculate answer
        /// </summary>
        /// <param name="output"></param>
        /// <param name="val1"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        private double CalculateAnswer(bool output, double val1, double val2)
        {
            return (output) ? Math.Round(Math.Sqrt(_trigCalculate.Calculate(val1, val2)), 3) :
                Math.Round(_trigCalculate.Calculate(val1, val2), 3);
        }

        /// <summary>
        /// Build the formula string to display on the solution window
        /// </summary>
        /// <param name="displayFormula"></param>
        /// <returns></returns>
        private string BuildFormula(bool displayFormula)
        {
            return (displayFormula) ? "Formula: " + _trigCalculate.Formula : "";
        }

        /// <summary>
        /// Build the answer context string to display on the solution window
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        private string BuildAnswerContext(bool output)
        {
            return (output) ? _trigCalculate.SideToFind.ToString() + " =" :
                _trigCalculate.SideToFind.ToString() + "^2 =";
        }
    }
}
