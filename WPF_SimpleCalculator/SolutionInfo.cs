using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SimpleCalculator
{
    public class SolutionInfo
    {
        public double TrigAnswer { get; set; }
        public string Formula { get; set; }
        public string AnswerContext { get; set; }

        public SolutionInfo(double trigAnswer, string formula, string answerContext)
        {
            TrigAnswer = trigAnswer;
            Formula = formula;
            AnswerContext = answerContext;
        }
    }
}
