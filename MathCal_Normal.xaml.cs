using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MathCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MathCal_Normal : Page
    {
        public MathCal_Normal()
        {
            this.InitializeComponent();
        }

        private void dowork(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = int.Parse(t1.Text);//value input
                double b = int.Parse(t2.Text);//value input
                string c = "";
                double d = 0;
                if (rdadd.IsChecked == true)//if ((bool)rdadd.IsChecked)
                {
                    (c, d) = Addition(a, b);
                }
                else if (rdsubtract.IsChecked == true)
                {
                    (c, d) = Subtraction(a, b);
                }
                else if (rdmultiple.IsChecked == true)
                {
                    (c, d) = Multiplication(a, b);
                }
                else if (rddiv.IsChecked == true)
                {
                    (c, d) = Division(a, b);
                }
                else if (rdremind.IsChecked == true)
                {
                    (c, d) = Reminder(a, b);
                }
                else
                {
                    MessageDialog m = new MessageDialog("Please Select any Operation");//new==class instantiate/onstructor
                    m.ShowAsync();
                }
                TextBlock5.Text = c;//value output
                TextBlock6.Text = d.ToString();
            }
            catch (FormatException fex)
            {
                MessageDialog m = new MessageDialog("Eiher the text has no valid value or blank");
                m.ShowAsync();
            }
            catch (OverflowException fex)
            {
                MessageDialog m = new MessageDialog("Value can not greater than 2147483648 for Int");
                m.ShowAsync();
            }
            catch (DivideByZeroException fex)
            {
                MessageDialog m = new MessageDialog("You cannot divide a number by zero");
                m.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog m = new MessageDialog(ex.Message);
                m.ShowAsync();
            }
        }

        private (string, double) Division(double a, double b)
        {
            double d = a / b;
            string c = string.Format("{0}/{1}={2}", a, b, d);
            return (c, d);
        }
        private (string, double) Reminder(double a, double b)
        {
            double d = a % b;
            string c = string.Format("{0}%{1}={2}", a, b, d);
            return (c,d);
        }

        private (string, double) Multiplication(double a, double b)
        {
            double d = a * b;
            string c = string.Format("{0}*{1}={2}", a, b, d);
            return (c, d);
        }

        private (string, double) Subtraction(double a, double b)
        {
            double d = a - b;
            string c= string.Format("{0}-{1}={2}", a, b, d);
            return (c, d);
        }

        private (string,double) Addition(double a, double b)
        {
            double output = a + b;
            string ex = string.Format("{0}+{1}={2}", a, b, output);
            return (ex, output);
        }
    }
}
