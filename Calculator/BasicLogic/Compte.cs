using System.Windows;

namespace Calculator.BasicLogic
{
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
