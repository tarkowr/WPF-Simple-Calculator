using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_SimpleCalculator
{
    /// <summary>
    /// Interaction logic for SolutionWindow.xaml
    /// </summary>
    public partial class SolutionWindow : Window
    {
        public SolutionInfo _solutionInfo { get; set; } 

        public SolutionWindow(SolutionInfo solutionInfo)
        {
            InitializeComponent();
            _solutionInfo = solutionInfo;
        }

        private void window_Solution_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_Solution.Background = Brushes.White;
            lbl_Solution.Content = $"{_solutionInfo.AnswerContext}";
            lbl_Solution.Content += $" { _solutionInfo.TrigAnswer}";

            if(_solutionInfo.Formula != "")
            {
                lbl_Formula.Content = _solutionInfo.Formula;
            }
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
