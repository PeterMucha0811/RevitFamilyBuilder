using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Mucha_WPFCustomControlLibrary.Components
{
    public partial class NumericUpDownControl : UserControl
    {
        // Dependency Property for TextBox Value
        public int NumberBoxValueProperty
        {
            get { return (int)GetValue(NumberBoxValuePropertyProperty); }
            set { SetValue(NumberBoxValuePropertyProperty, value); }
        }

        public static readonly DependencyProperty NumberBoxValuePropertyProperty =
            DependencyProperty.Register("NumberBoxValueProperty",
                typeof(int), typeof(NumericUpDownControl),
                new PropertyMetadata(0));


        private bool isIncrementing;
        private bool isDecrementing;

        public NumericUpDownControl()
        {
            InitializeComponent();
        }

        private void OnIncrementClick(object sender, RoutedEventArgs e)
        {
            IncrementValue();
        }

        private void OnDecrementClick(object sender, RoutedEventArgs e)
        {
            DecrementValue();
        }

        private void OnIncrementMouseDown(object sender, MouseButtonEventArgs e)
        {
            isIncrementing = true;
            StartIncrementTimer();
        }

        private void OnIncrementMouseUp(object sender, MouseButtonEventArgs e)
        {
            isIncrementing = false;
            StopIncrementTimer();
        }

        private void OnDecrementMouseDown(object sender, MouseButtonEventArgs e)
        {
            isDecrementing = true;
            StartDecrementTimer();
        }

        private void OnDecrementMouseUp(object sender, MouseButtonEventArgs e)
        {
            isDecrementing = false;
            StopDecrementTimer();
        }

        private void IncrementValue()
        {
            NumberBoxValueProperty++;
        }

        private void DecrementValue()
        {
            NumberBoxValueProperty--;
        }

        private void StartIncrementTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += (s, e) =>
            {
                if (isIncrementing)
                    IncrementValue();
                else
                    timer.Stop();
            };
            timer.Start();
        }

        private void StopIncrementTimer()
        {
            // No action needed here
        }

        private void StartDecrementTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += (s, e) =>
            {
                if (isDecrementing)
                    DecrementValue();
                else
                    timer.Stop();
            };
            timer.Start();
        }

        private void StopDecrementTimer()
        {
            // No action needed here
        }
    }
}