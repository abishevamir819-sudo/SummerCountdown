namespace SummerCountdown;

public partial class MainPage : ContentPage
{
    private IDispatcherTimer _timer = null!;
    private DateTime _targetDate = new DateTime(2027, 6, 1, 0, 0, 0); // 1 июня 2027 года

    public MainPage()
    {
        InitializeComponent();
        SetupTimer();
    }

    private void SetupTimer()
    {
        _timer = Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += (s, e) => UpdateCountdown();
        _timer.Start();
    }

    private void UpdateCountdown()
    {
        var now = DateTime.Now;
        if (now >= _targetDate) return;

        var timeLeft = _targetDate - now;

        int months = (_targetDate.Year - now.Year) * 12 + _targetDate.Month - now.Month;
        if (_targetDate.Day < now.Day) months--;

        int weeks = (int)(timeLeft.Days / 7);
        int days = timeLeft.Days % 7;
        int hours = timeLeft.Hours;
        int minutes = timeLeft.Minutes;
        int seconds = timeLeft.Seconds;

        MonthsLabel.Text = months.ToString();
        WeeksLabel.Text = weeks.ToString();
        DaysLabel.Text = days.ToString();
        HoursLabel.Text = hours.ToString();
        MinutesLabel.Text = minutes.ToString();
        SecondsLabel.Text = seconds.ToString();
    }
}
