using System;
using System.Windows;
using System.Windows.Input;



namespace CountingHours
{
    public partial class MainWindow
    {
        private DateTime Time { get; set; }

        private const string DefaultZeroTime = "0h 0m";

        private void AddTimeGui(DateTime addedTime)
        {
            if (time.Text != DefaultZeroTime)
            {
                new_time.Text = "+ " + addedTime.Hour + "h " + addedTime.Minute + "m";
            }
            time.Text = Time.Hour + "h " + Time.Minute + "m";
            hours_start.Focus();
            SelectAllTime();
        }

        private DateTime CountingTime()
        {
            var addedTime = new DateTime();
            try
            {
                var one = new DateTime(1, 1, 1, Convert.ToInt32(hours_start.Text), Convert.ToInt32(minutes_start.Text), 0);
                var two = new DateTime(1, 1, 1, Convert.ToInt32(hours_end.Text), Convert.ToInt32(minutes_end.Text), 0);
                Time += two - one;
                addedTime += two - one;
                return addedTime;
            }
            catch
            {
                MessageBox.Show("3n73r NUM83R5", "Shit");
                return addedTime;
            }
        }

        private void AddTime()
        {
            AddTimeGui(CountingTime());
            Clipboard.SetText(time.Text);
        }

        private void SelectAllTime()
        {
            hours_start.SelectAll();
            hours_end.SelectAll();
            minutes_start.SelectAll();
            minutes_end.SelectAll();
        }

        private void ClearTimeEditBox()
        {
            hours_start.Clear();
            minutes_start.Clear();
            hours_end.Clear();
            minutes_end.Clear();
        }

        private void Reset()
        {
            ClearTimeEditBox();
            time.Text = DefaultZeroTime;
            new_time.Text = "";
            Time = new DateTime();
        }

        private void button_Click(object sender, RoutedEventArgs e) => AddTime();

        private void clear_button_Click(object sender, RoutedEventArgs e) => Reset();

        public ICommand AddTimeCommand => new ActionCommand(AddTime);

        public ICommand ResetCommand => new ActionCommand(Reset);

        public MainWindow()
        {
            InitializeComponent();
            Reset();
            DataContext = this;
            hours_start.Focus();
        }
    }
}
