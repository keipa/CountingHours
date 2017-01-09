using System;
using System.Windows;
using System.Windows.Input;



namespace CountingHours
{
    public partial class MainWindow : Window
    {
        private DateTime Time { get; set; }
        public ICommand AddTimeCommand => new ActionCommand(AddTime);
        public ICommand ResetCommand => new ActionCommand(Reset);
        private const string DefaultZeroTime = "0h 0m";

        public MainWindow()
        {
            InitializeComponent();
            Reset();
            DataContext = this;
            hours_start.Focus();
        }

        private void button_Click(object sender, RoutedEventArgs e) => AddTime();

        private void AddTime()
        {
            try
            {
                var one = new DateTime(1, 1, 1, Convert.ToInt32(hours_start.Text), Convert.ToInt32(minutes_start.Text), 0);
                var two = new DateTime(1, 1, 1, Convert.ToInt32(hours_end.Text), Convert.ToInt32(minutes_end.Text), 0);
                var addedTime = new DateTime();
                Time += two - one;
                addedTime += two - one;
                if (time.Text != DefaultZeroTime)
                    new_time.Text = "+ " + addedTime.Hour + "h " + addedTime.Minute + "m";
                time.Text = Time.Hour + "h " + Time.Minute + "m";
                Clipboard.SetText(time.Text);
                hours_start.Focus();
                SelectAllTime();
            }
            catch (Exception e)
            {
                MessageBox.Show("3n73r NUM83R5", "Shit");
            }
        }

        private void SelectAllTime()
        {
            hours_start.SelectAll();
            hours_end.SelectAll();
            minutes_start.SelectAll();
            minutes_end.SelectAll();
        }


        private void Reset()
        {
            hours_start.Clear();
            minutes_start.Clear();
            hours_end.Clear();
            minutes_end.Clear();
            time.Text = DefaultZeroTime;
            new_time.Text = "";
            Time = new DateTime();
        }

        private void clear_button_Click(object sender, RoutedEventArgs e) => Reset();
    }
}
