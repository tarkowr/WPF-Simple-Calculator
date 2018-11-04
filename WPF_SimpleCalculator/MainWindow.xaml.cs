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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_SimpleCalculator.BusinessAccessLayer;

namespace WPF_SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BusinessLayer _bal = new BusinessLayer();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void radioBox_AB_Click(object sender, RoutedEventArgs e)
        {
            lbl_Val1.Content = "A (units)";
            lbl_Val2.Content = "B (units)";
            radioBtn_Val.Content = "C";
            radioBtn_ValSq.Content = "C^2";
        }

        private void radioBox_AC_Click(object sender, RoutedEventArgs e)
        {
            lbl_Val1.Content = "A (units)";
            lbl_Val2.Content = "C (units)";
            radioBtn_Val.Content = "B";
            radioBtn_ValSq.Content = "B^2";
        }

        private void radioBox_BC_Click(object sender, RoutedEventArgs e)
        {
            lbl_Val1.Content = "B (units)";
            lbl_Val2.Content = "C (units)";
            radioBtn_Val.Content = "A";
            radioBtn_ValSq.Content = "A^2";
        }

        private void btn_Calculate_Click(object sender, RoutedEventArgs e)
        {
            double val1 = 0, val2 = 0;
            double output;
            int numberOfErrors = 0;
            string message = "", customMessage = "";

            //Handle Value One
            if (_bal.ValidateInput(txtBox_Val1.Text, out output, out message))
            {
                val1 = output;
                if (lbl_Error1.Content != "")
                {
                    lbl_Error1.Content = "";
                }
            }
            else
            {
                customMessage = "This value " + message;
                lbl_Error1.Content = customMessage;
                numberOfErrors++;
            }

            //Handle Value Two
            if (_bal.ValidateInput(txtBox_Val2.Text, out output, out message))
            {
                val2 = output;
                if (lbl_Error2.Content != "")
                {
                    lbl_Error2.Content = "";
                }
            }
            else
            {
                customMessage = "This value " + message;
                lbl_Error2.Content = customMessage;
                numberOfErrors++;
            }

            _bal.SetCalculationType((bool)radioBox_AB.IsChecked, (bool)radioBox_AC.IsChecked, (bool)radioBox_BC.IsChecked);

            //Check if the input will create a valid Trig Function
            if (!(_bal.ValidTrigFunction(val1, val2, out message)))
            {
                lbl_Error1.Content = message;
                numberOfErrors++;
            }

            //Calculate the Solution if there are no errors
            if (!(numberOfErrors > 0))
            {
                _bal.CalculateAndDisplayTrigAnswer((bool)checkBox_Formula.IsChecked, (bool)radioBtn_Val.IsChecked, val1, val2);
            }
        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            txtBox_Val1.Text = "";
            txtBox_Val2.Text = "";
            lbl_Error1.Content = "";
            lbl_Error2.Content = "";
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }
    }
}
