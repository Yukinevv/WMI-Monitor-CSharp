using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ZarzadzanieUsluga.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy CircularProgressBar.xaml
    /// </summary>
    public partial class CircularProgressBar : UserControl
    {
        SolidColorBrush brush = new SolidColorBrush();

        public CircularProgressBar()
        {
            InitializeComponent();
        }

        public void SetProgress(double value, double divider)
        {
            short percentageValue = CalculatePercentageValue(value, divider);

            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                Progress.EndAngle = (value / divider) * 360;
                if (percentageValue <= 30)
                {
                    brush = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                }
                else if (percentageValue > 30 && percentageValue < 70)
                {
                    brush = new SolidColorBrush(Color.FromArgb(255, 255, 139, 0));
                }
                else if (percentageValue >= 70 && percentageValue < 90)
                {
                    brush = new SolidColorBrush(Color.FromArgb(255, 255, 80, 0));
                }
                else
                {
                    brush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                }
                Progress.Fill = brush;
                PgPerentage.Foreground = brush;
                PgPerentage.Content = percentageValue.ToString() + "%";
            }));
        }

        public static short CalculatePercentageValue(double value, double divider)
        {
            if (value < 0 || divider <= 0)
            {
                throw new ArgumentOutOfRangeException("Negative value or negative or equal divider");
            }

            return Convert.ToInt16((value / divider) * 100);
        }
    }
}
