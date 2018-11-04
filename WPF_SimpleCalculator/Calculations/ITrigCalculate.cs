using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SimpleCalculator.Calculations
{
    public interface ITrigCalculate
    {
        string Formula { get; set; }
        Sides SideToFind { get; set; }
        double Calculate(double val1, double val2);
        bool ValidInput(double val1, double val2, out string message);
    }
}
