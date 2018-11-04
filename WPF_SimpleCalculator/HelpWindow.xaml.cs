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
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_HelpText.Content = 
                "How to use this Calculator:" + Environment.NewLine + Environment.NewLine +
                "1) Select the two known sides of the right triangle for the Pythagorean Theorem." + Environment.NewLine +
                "2) Enter the side length of both sides in their respective text box." + Environment.NewLine +
                "3) Check the checkbox if you wish to see the formula in calculating your answer." + Environment.NewLine +
                "4) Specify how you would like the output, squared or not squared." + Environment.NewLine +
                "5) Click the Calculate button to see the answer.";
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
