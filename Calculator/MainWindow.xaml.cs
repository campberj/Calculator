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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();
            resultLabel.Content = "0";

        }

        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(resultLabel.Content.ToString().Contains(".")))
            {
                resultLabel.Content += ".";
            }
           
        }

        private void equalsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if(double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch(selectedOperator)
                {
                    case SelectedOperator.Addition:
                       result = SimpleMath.Add(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtract(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;

                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;

                }

                resultLabel.Content = result.ToString();
            }

        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
                if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
                {
                    resultLabel.Content = "0";

                }

                if(sender == multiplicationButton)
                {
                    selectedOperator = SelectedOperator.Multiplication;
                }
                if(sender == divisionButton)
                {
                    selectedOperator = SelectedOperator.Division;
                }
                if (sender == additionButton)
                {
                    selectedOperator = SelectedOperator.Addition;
                }
                if (sender == subtractionButton)
                {
                    selectedOperator = SelectedOperator.Subtraction;
                }

        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;

            if (sender == zeroButton)
                selectedValue = 0;
            if (sender == oneButton)
                selectedValue = 1;
            if (sender == twoButton)
                selectedValue = 2;
            if (sender == threeButton)
                selectedValue = 3;
            if (sender == fourButton)
                selectedValue = 4;
            if (sender == fiveButton)
                selectedValue = 5;
            if (sender == sixButton)
                selectedValue = 6;
            if (sender == sevenButton)
                selectedValue = 7;
            if (sender == eightButton)
                selectedValue = 8;
            if (sender == nineButton)
                selectedValue = 9;

            if (resultLabel.Content.ToString() == "0") 
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }

        #region Operation Button Methods
        private void subtractionButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                result = lastNumber - double.Parse(resultLabel.Content.ToString());
                resultLabel.Content = $"{result }";
            }
        }

        private void negativeButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void percentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void acButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }
        #endregion
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Subtract(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Division by zero is not supported.", "Wrong operation", MessageBoxButton.OK,MessageBoxImage.Error);

                return 0;
            }

            return n1 / n2;
        }
    }
}
