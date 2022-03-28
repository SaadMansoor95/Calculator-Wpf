using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber, result;
        private SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentButton.Click += PercentButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;

            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = Compute.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = Compute.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = Compute.Multiple(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = Compute.Divede(lastNumber, newNumber);
                        break;
                    default:
                        break;
                }
            }
            resultLabel.Content = result;
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);

                if (lastNumber != 0)
                    tempNumber *= lastNumber;

                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
                resultLabel.Content = "0";

            var pressedButton = (Button)sender;

            switch (pressedButton.Name)
            {
                case nameof(plusButton): selectedOperator = SelectedOperator.Addition; break;
                case nameof(minusButton): selectedOperator = SelectedOperator.Subtraction; break;
                case nameof(multipleButton): selectedOperator = SelectedOperator.Multiplication; break;
                case nameof(divideButton): selectedOperator = SelectedOperator.Division; break;
                default:
                    break;
            }
        }

        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
                resultLabel.Content = $"{resultLabel.Content}.";
        }

        private void numberButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            var selectedValue = 0;
            
            var pressedButton = (Button)sender;

            switch (pressedButton.Name)
            {
                case nameof(zeroButton): selectedValue = 0; break;
                case nameof(oneButton): selectedValue = 1; break;
                case nameof(twoButton): selectedValue = 2; break;
                case nameof(threeButton): selectedValue = 3; break;
                case nameof(fourButton): selectedValue = 4; break;
                case nameof(fiveButton): selectedValue = 5; break;
                case nameof(sixButton): selectedValue = 6; break;
                case nameof(sevenButton): selectedValue = 7; break;
                case nameof(eightButton): selectedValue = 8; break;
                case nameof(nineButton): selectedValue = 9; break;
                default:
                    break;
            }*/

            //Another way simply get sender Content

            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLabel.Content.ToString() == "0")
                resultLabel.Content = selectedValue;
            else
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
    }

    public static class Compute
    {
        public static double Add(double first, double second)
        {
            return first + second;
        }
        public static double Subtract(double first, double second)
        {
            return first - second;
        }
        public static double Multiple(double first, double second)
        {
            return first * second;
        }
        public static double Divede(double first, double second)
        {
            if (second == 0)
            {
                MessageBox.Show("Cannot divide by 0", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }

            return first / second;
        }
    }
}