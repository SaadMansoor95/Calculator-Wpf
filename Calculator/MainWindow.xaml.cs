using Calculator.BasicLogic;
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

            if (double.TryParse(resultLabel.Text.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.ADDITION:
                        result = Compute.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.SUBTRACTION:
                        result = Compute.Subtract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.MULTIPLICATION:
                        result = Compute.Multiple(lastNumber, newNumber);
                        break;
                    case SelectedOperator.DIVISION:
                        result = Compute.Divede(lastNumber, newNumber);
                        break;
                    default:
                        break;
                }
            }
            resultLabel.Text = result.ToString();
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Text.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);

                if (lastNumber != 0)
                    tempNumber *= lastNumber;

                resultLabel.Text = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Text.ToString(), out lastNumber))
            {
                if (lastNumber.Equals(0))
                    return;

                lastNumber = lastNumber * -1;
                resultLabel.Text = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Text = "0";
            lastNumber = 0;
            result = 0;
        }

        private void operationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Text.ToString(), out lastNumber))
                resultLabel.Text = "0";

            var pressedButton = (Button)sender;

            switch (pressedButton.Name)
            {
                case nameof(plusButton): selectedOperator = SelectedOperator.ADDITION; break;
                case nameof(minusButton): selectedOperator = SelectedOperator.SUBTRACTION; break;
                case nameof(multipleButton): selectedOperator = SelectedOperator.MULTIPLICATION; break;
                case nameof(divideButton): selectedOperator = SelectedOperator.DIVISION; break;
                default:
                    break;
            }
        }

        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Text.ToString().Contains("."))
                resultLabel.Text = $"{resultLabel.Text}.";
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

            //Another way simply get sender Text

            int selectedValue = int.Parse((sender as Button).Content.ToString());

            if (resultLabel.Text.ToString() == "0")
                resultLabel.Text = selectedValue.ToString();
            else
                resultLabel.Text = $"{resultLabel.Text}{selectedValue}";
        }
    }
}