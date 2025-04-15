using Syncfusion.Maui.Scheduler;
using System.Collections.ObjectModel;

namespace SchedulerSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            scheduler.TimelineView.TimeRegions = GetTimeRegion();
        }

        private ObservableCollection<SchedulerTimeRegion> GetTimeRegion()
        {
            var style1 = new SchedulerTextStyle()
            {
                TextColor = Colors.DarkBlue,
                FontSize = 14
            };

            var style2 = new SchedulerTextStyle()
            {
                TextColor = Colors.White,
                FontSize = 14
            };

            var timeRegions = new ObservableCollection<SchedulerTimeRegion>();
            var recurrenceExceptionDates = DateTime.Now.Date.AddDays(3);

            var lunchTimeRegion = new SchedulerTimeRegion()
            {
                StartTime = DateTime.Today.Date.AddHours(13),
                EndTime = DateTime.Today.Date.AddHours(14),
                Text = "Lunch",
                EnablePointerInteraction = false,
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1",
                RecurrenceExceptionDates = new ObservableCollection<DateTime>
                {
                    recurrenceExceptionDates
                },
                Background = Brush.LightGray,
                TextStyle = style1,
                ResourceIds = new ObservableCollection<object>() { "1", "2", "3" }
            };

            var breakTimeRegion = new SchedulerTimeRegion()
            {
                StartTime = DateTime.Today.Date.AddHours(17),
                EndTime = DateTime.Today.Date.AddHours(18),
                Text = "Break",
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1",
                Background = Brush.LightSlateGray,
                TextStyle = style2,
                ResourceIds = new ObservableCollection<object>() { "1", "2", "3" }
            };

            timeRegions.Add(lunchTimeRegion);
            timeRegions.Add(breakTimeRegion);
            return timeRegions;
        }
    }

    public class ViewModel
    {
        public ObservableCollection<SchedulerAppointment>? Events { get; set; }
        public ObservableCollection<SchedulerResource>? ResourceCollection { get; set; }

        public ViewModel()
        {
            GeneratingResources();
            GeneratingAppointments();
        }

        internal void GeneratingAppointments()
        {
            Events = new ObservableCollection<SchedulerAppointment>()
            {
                new SchedulerAppointment()
                {
                    Subject = "General Meeting",
                    StartTime = DateTime.Today.AddHours(10),
                    EndTime = DateTime.Today.AddHours(11),
                    Background = Colors.Green,
                    RecurrenceRule = "FREQ=DAILY;INTERVAL=1",
                    ResourceIds = new ObservableCollection<object>() { "1", "2", "3" }
                },

                new SchedulerAppointment()
                {
                    Subject = "Consulting",
                    StartTime = DateTime.Today.AddHours(15),
                    EndTime = DateTime.Today.AddHours(16),
                    Background = Colors.Violet,
                    ResourceIds = new ObservableCollection<object>() { "1", "3" }

                }
            };
        }

        private void GeneratingResources()
        {
            ResourceCollection = new ObservableCollection<SchedulerResource>()
            {
                new SchedulerResource(){Name="Stephen",Id="1",Background = new SolidColorBrush(Color.FromArgb("#375E97")), Foreground = Colors.White },
                new SchedulerResource(){Name="Zoey",Id="2",Background = new SolidColorBrush(Color.FromArgb("#FB6542")), Foreground = Colors.White },
                new SchedulerResource(){Name="Emilia",Id="3",Background = new SolidColorBrush(Color.FromArgb("#FFBB00")), Foreground = Colors.Black }
            };
        }
    }
}
