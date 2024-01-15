using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core.Platform;
using Core.Const;
using Core.Entity;
using MiracleApp.Services.Lesson;
using MiracleApp.Services.User;
using MiracleApp.Validation;
using System.Globalization;

namespace MiracleApp.Pages;

class LessonShowProperties
{
    public string cource { get; set; }

    public string department { get; set; }

    public string branch { get; set; }
}

class Lesson
{
     public string Description { get; set; }

    public string TimeStart { get; set; }

    public string TimeEnd { get; set; }

    public string Where { get; set; }

}

  class DayOfWeekN
{
    public string Name { get; set; }
}

class LessonTime
{
    public string Time { get; set; }
}

public partial class SchedulePage : ContentPage
{
    LessonShowProperties prop = new();
    Calendar calendar = CultureInfo.CurrentCulture.Calendar;
    LessonEntity lesson = new();
    UserEntity user = new();
    StatusBarBehavior statusBar = new();
    List<DayOfWeekN> dow = new()
    {
        new() { Name = "Ïîíåäåëüíèê" },
        new() { Name = "Âòîðíèê" },
        new() { Name = "Ñðåäà" },
        new() { Name = "×åòâåðã" },
        new() { Name = "Ïÿòíèöà" },
        new() { Name = "Ñóááîòà" },
        new() { Name = "Âîñêðåñåíüå" }
    };
    List<LessonTime> lesson_times = new()
    {
        new() {Time = "00:00"},
        new() {Time = "00:05"},
        new() {Time = "00:10"},
        new() {Time = "00:15"},
        new() {Time = "00:20"},
        new() {Time = "00:25"},
        new() {Time = "00:30"},
        new() {Time = "00:35"},
        new() {Time = "00:40"},
        new() {Time = "00:45"},
        new() {Time = "00:50"},
        new() {Time = "00:55"},
        new() {Time = "01:00"},
        new() {Time = "01:05"},
        new() {Time = "01:10"},
        new() {Time = "01:15"},
        new() {Time = "01:20"},
        new() {Time = "01:25"},
        new() {Time = "01:30"},
        new() {Time = "01:35"},
        new() {Time = "01:40"},
        new() {Time = "01:45"},
        new() {Time = "01:50"},
        new() {Time = "01:55"},
        new() {Time = "02:00"},
        new() {Time = "02:05"},
        new() {Time = "02:10"},
        new() {Time = "02:15"},
        new() {Time = "02:20"},
        new() {Time = "02:25"},
        new() {Time = "02:30"},
        new() {Time = "02:35"},
        new() {Time = "02:40"},
        new() {Time = "02:45"},
        new() {Time = "02:50"},
        new() {Time = "02:55"},
        new() {Time = "03:00"},
        new() {Time = "03:05"},
        new() {Time = "03:10"},
        new() {Time = "03:15"},
        new() {Time = "03:20"},
        new() {Time = "03:25"},
        new() {Time = "03:30"},
        new() {Time = "03:35"},
        new() {Time = "03:40"},
        new() {Time = "03:45"},
        new() {Time = "03:50"},
        new() {Time = "03:55"},
        new() {Time = "04:00"},
        new() {Time = "04:05"},
        new() {Time = "04:10"},
        new() {Time = "04:15"},
        new() {Time = "04:20"},
        new() {Time = "04:25"},
        new() {Time = "04:30"},
        new() {Time = "04:35"},
        new() {Time = "04:40"},
        new() {Time = "04:45"},
        new() {Time = "04:50"},
        new() {Time = "04:55"},
        new() {Time = "05:00"},
        new() {Time = "05:05"},
        new() {Time = "05:10"},
        new() {Time = "05:15"},
        new() {Time = "05:20"},
        new() {Time = "05:25"},
        new() {Time = "05:30"},
        new() {Time = "05:35"},
        new() {Time = "05:40"},
        new() {Time = "05:45"},
        new() {Time = "05:50"},
        new() {Time = "05:55"},
        new() {Time = "06:00"},
        new() {Time = "06:05"},
        new() {Time = "06:10"},
        new() {Time = "06:15"},
        new() {Time = "06:20"},
        new() {Time = "06:25"},
        new() {Time = "06:30"},
        new() {Time = "06:35"},
        new() {Time = "06:40"},
        new() {Time = "06:45"},
        new() {Time = "06:50"},
        new() {Time = "06:55"},
        new() {Time = "07:00"},
        new() {Time = "07:05"},
        new() {Time = "07:10"},
        new() {Time = "07:15"},
        new() {Time = "07:20"},
        new() {Time = "07:25"},
        new() {Time = "07:30"},
        new() {Time = "07:35"},
        new() {Time = "07:40"},
        new() {Time = "07:45"},
        new() {Time = "07:50"},
        new() {Time = "07:55"},
        new() {Time = "08:00"},
        new() {Time = "08:05"},
        new() {Time = "08:10"},
        new() {Time = "08:15"},
        new() {Time = "08:20"},
        new() {Time = "08:25"},
        new() {Time = "08:30"},
        new() {Time = "08:35"},
        new() {Time = "08:40"},
        new() {Time = "08:45"},
        new() {Time = "08:50"},
        new() {Time = "08:55"},
        new() {Time = "09:00"},
        new() {Time = "09:05"},
        new() {Time = "09:10"},
        new() {Time = "09:15"},
        new() {Time = "09:20"},
        new() {Time = "09:25"},
        new() {Time = "09:30"},
        new() {Time = "09:35"},
        new() {Time = "09:40"},
        new() {Time = "09:45"},
        new() {Time = "09:50"},
        new() {Time = "09:55"},
        new() {Time = "10:00"},
        new() {Time = "10:05"},
        new() {Time = "10:10"},
        new() {Time = "10:15"},
        new() {Time = "10:20"},
        new() {Time = "10:25"},
        new() {Time = "10:30"},
        new() {Time = "10:35"},
        new() {Time = "10:40"},
        new() {Time = "10:45"},
        new() {Time = "10:50"},
        new() {Time = "10:55"},
        new() {Time = "11:00"},
        new() {Time = "11:05"},
        new() {Time = "11:10"},
        new() {Time = "11:15"},
        new() {Time = "11:20"},
        new() {Time = "11:25"},
        new() {Time = "11:30"},
        new() {Time = "11:35"},
        new() {Time = "11:40"},
        new() {Time = "11:45"},
        new() {Time = "11:50"},
        new() {Time = "11:55"},
        new() {Time = "12:00"},
        new() {Time = "12:05"},
        new() {Time = "12:10"},
        new() {Time = "12:15"},
        new() {Time = "12:20"},
        new() {Time = "12:25"},
        new() {Time = "12:30"},
        new() {Time = "12:35"},
        new() {Time = "12:40"},
        new() {Time = "12:45"},
        new() {Time = "12:50"},
        new() {Time = "12:55"},
        new() {Time = "13:00"},
        new() {Time = "13:05"},
        new() {Time = "13:10"},
        new() {Time = "13:15"},
        new() {Time = "13:20"},
        new() {Time = "13:25"},
        new() {Time = "13:30"},
        new() {Time = "13:35"},
        new() {Time = "13:40"},
        new() {Time = "13:45"},
        new() {Time = "13:50"},
        new() {Time = "13:55"},
        new() {Time = "14:00"},
        new() {Time = "14:05"},
        new() {Time = "14:10"},
        new() {Time = "14:15"},
        new() {Time = "14:20"},
        new() {Time = "14:25"},
        new() {Time = "14:30"},
        new() {Time = "14:35"},
        new() {Time = "14:40"},
        new() {Time = "14:45"},
        new() {Time = "14:50"},
        new() {Time = "14:55"},
        new() {Time = "15:00"},
        new() {Time = "15:05"},
        new() {Time = "15:10"},
        new() {Time = "15:15"},
        new() {Time = "15:20"},
        new() {Time = "15:25"},
        new() {Time = "15:30"},
        new() {Time = "15:35"},
        new() {Time = "15:40"},
        new() {Time = "15:45"},
        new() {Time = "15:50"},
        new() {Time = "15:55"},
        new() {Time = "16:00"},
        new() {Time = "16:05"},
        new() {Time = "16:10"},
        new() {Time = "16:15"},
        new() {Time = "16:20"},
        new() {Time = "16:25"},
        new() {Time = "16:30"},
        new() {Time = "16:35"},
        new() {Time = "16:40"},
        new() {Time = "16:45"},
        new() {Time = "16:50"},
        new() {Time = "16:55"},
        new() {Time = "17:00"},
        new() {Time = "17:05"},
        new() {Time = "17:10"},
        new() {Time = "17:15"},
        new() {Time = "17:20"},
        new() {Time = "17:25"},
        new() {Time = "17:30"},
        new() {Time = "17:35"},
        new() {Time = "17:40"},
        new() {Time = "17:45"},
        new() {Time = "17:50"},
        new() {Time = "17:55"},
        new() {Time = "18:00"},
        new() {Time = "18:05"},
        new() {Time = "18:10"},
        new() {Time = "18:15"},
        new() {Time = "18:20"},
        new() {Time = "18:25"},
        new() {Time = "18:30"},
        new() {Time = "18:35"},
        new() {Time = "18:40"},
        new() {Time = "18:45"},
        new() {Time = "18:50"},
        new() {Time = "18:55"},
        new() {Time = "19:00"},
        new() {Time = "19:05"},
        new() {Time = "19:10"},
        new() {Time = "19:15"},
        new() {Time = "19:20"},
        new() {Time = "19:25"},
        new() {Time = "19:30"},
        new() {Time = "19:35"},
        new() {Time = "19:40"},
        new() {Time = "19:45"},
        new() {Time = "19:50"},
        new() {Time = "19:55"},
        new() {Time = "20:00"},
        new() {Time = "20:05"},
        new() {Time = "20:10"},
        new() {Time = "20:15"},
        new() {Time = "20:20"},
        new() {Time = "20:25"},
        new() {Time = "20:30"},
        new() {Time = "20:35"},
        new() {Time = "20:40"},
        new() {Time = "20:45"},
        new() {Time = "20:50"},
        new() {Time = "20:55"},
        new() {Time = "21:00"},
        new() {Time = "21:05"},
        new() {Time = "21:10"},
        new() {Time = "21:15"},
        new() {Time = "21:20"},
        new() {Time = "21:25"},
        new() {Time = "21:30"},
        new() {Time = "21:35"},
        new() {Time = "21:40"},
        new() {Time = "21:45"},
        new() {Time = "21:50"},
        new() {Time = "21:55"},
        new() {Time = "22:00"},
        new() {Time = "22:05"},
        new() {Time = "22:10"},
        new() {Time = "22:15"},
        new() {Time = "22:20"},
        new() {Time = "22:25"},
        new() {Time = "22:30"},
        new() {Time = "22:35"},
        new() {Time = "22:40"},
        new() {Time = "22:45"},
        new() {Time = "22:50"},
        new() {Time = "22:55"},
        new() {Time = "23:00"},
        new() {Time = "23:05"},
        new() {Time = "23:10"},
        new() {Time = "23:15"},
        new() {Time = "23:20"},
        new() {Time = "23:25"},
        new() {Time = "23:30"},
        new() {Time = "23:35"},
        new() {Time = "23:40"},
        new() {Time = "23:45"},
        new() {Time = "23:50"},
        new() {Time = "23:55"},
    };

    List<LessonTime> lesson_hours = new()
    {
        new() {Time = "00" },
        new() {Time = "01" },
        new() {Time = "02" },
        new() {Time = "03" },
        new() {Time = "04" },
        new() {Time = "05" },
        new() {Time = "06" },
        new() {Time = "06" },
        new() {Time = "07" },
        new() {Time = "08" },
        new() {Time = "09" },
        new() {Time = "10" },
        new() {Time = "11" },
        new() {Time = "12" },
        new() {Time = "13" },
        new() {Time = "14" },
        new() {Time = "15" },
        new() {Time = "16" },
        new() {Time = "16" },
        new() {Time = "17" },
        new() {Time = "18" },
        new() {Time = "19" },
        new() {Time = "20" },
        new() {Time = "21" },
        new() {Time = "22" },
        new() {Time = "23" }
    };

    List<LessonTime> lesson_minutes = new()
    {
        new() {Time = "00"},
        new() {Time = "05"},
        new() {Time = "10"},
        new() {Time = "15"},
        new() {Time = "20"},
        new() {Time = "25"},
        new() {Time = "30"},
        new() {Time = "35"},
        new() {Time = "40"},
        new() {Time = "45"},
        new() {Time = "50"},
        new() {Time = "55"}
    };

    string cur_hour, cur_minute;

    public SchedulePage()
    {
        if (!UserValid.UserAuth())
        {
            Navigation.PushAsync(new HelloPage());
        }
        InitializeComponent();
        Dispatcher.Dispatch(async () =>
        {
           
            if (await SecureStorage.GetAsync("role") == "3")
            {
                DoWChoiceCV.ItemsSource = dow;
                //StartHourChoiceCV.ItemsSource = lesson_hours;
                //StartMinuteChoiceCV.ItemsSource = lesson_minutes;
                StartChoiceCV.ItemsSource = lesson_times;
                cur_hour = lesson_hours.First().Time;
                cur_minute = lesson_minutes.First().Time;
            }
            else
            {
                StudentScheduleSL.IsVisible = true;
                MondaySL.IsVisible = false;
                TuesdaySL.IsVisible = false;
                WednesdaySL.IsVisible = false;
                ThursdaySL.IsVisible = false;
                FridaySL.IsVisible = false;
                SaturdaySL.IsVisible = false;
                SundaySL.IsVisible = false;
                CourseChoiceSL.IsVisible = true;
                BranchChoiceSL.IsVisible = true;
                DepartmentChoiceSL.IsVisible = true;
            }
        });


        statusBar.StatusBarColor = Color.FromArgb("#8031A7");
    }

    private async void MainButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
        MainButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        ScheduleButton.BackgroundColor = Colors.Transparent;
        PayButton.BackgroundColor = Colors.Transparent;
        ÑertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void ScheduleButton_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new SchedulePage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        PayButton.BackgroundColor = Colors.Transparent;
        ÑertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void PayButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PayPage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Colors.Transparent;
        PayButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        ÑertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void ÑertificateButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CertificatePage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Colors.Transparent;
        PayButton.BackgroundColor = Colors.Transparent;
        ÑertificateButton.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void CourceOneButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#1E1E1E");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceFourButton.BackgroundColor = Color.FromArgb("#9F5CC0");

        Cource1Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        Cource2Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Cource3Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Cource4Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.cource = "1";
    }

    private void CourceTwoButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#1E1E1E");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceFourButton.BackgroundColor = Color.FromArgb("#9F5CC0");

        Cource1Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Cource2Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        Cource3Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Cource4Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.cource = "2";
    }

    private void CourceThreeButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#1E1E1E");
        CourceFourButton.BackgroundColor = Color.FromArgb("#9F5CC0");

        Cource1Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Cource2Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Cource3Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        Cource4Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.cource = "3";
    }

    private void CourceFourButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceFourButton.BackgroundColor = Color.FromArgb("#1E1E1E");

        Cource1Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Cource2Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Cource3Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Cource4Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        prop.cource = "4";
    }

    private void Department1_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");

        Department1Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department2Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.department = "1";
    }

    private void Department2_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");

        Department1Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department3Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.department = "2";
    }

    private void Department3_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");

        Department1Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department4Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.department = "3";
    }

    private void Department4_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");

        Department1Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department5Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.department = "4";
    }

    private void Department5_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#1E1E1E");

        Department1Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        prop.department = "5";
    }

    private void Branch1_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");

        Branch1Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch2Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.branch = "1";
    }

    private void Branch2_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");

        Branch1Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch3Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.branch = "2";
    }

    private void Branch3_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");

        Branch1Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch4Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.branch = "3";
    }

    private void Branch4_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");

        Branch1Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch5Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.branch = "4";
    }

    private void Branch5_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");

        Branch1Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch6Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.branch = "5";
    }

    private void Branch6_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#1E1E1E");

        Branch1Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5Frame.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6Frame.BackgroundColor = Color.FromArgb("#1E1E1E");
        prop.branch = "6";
    }

    private void ShowLessonsButton_Clicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(prop.cource))
        {
            if (!string.IsNullOrEmpty(prop.department))
            {
                if (!string.IsNullOrEmpty(prop.branch))
                {
                    List<Lesson> showlistMo = new();
                    List<Lesson> showlistTu = new();
                    List<Lesson> showlistWe = new();
                    List<Lesson> showlistTh = new();
                    List<Lesson> showlistFr = new();
                    List<Lesson> showlistSa = new();
                    List<Lesson> showlistSu = new();
                    List<LessonEntity> lessons = new();
                    Dispatcher.Dispatch(async () =>
                    {
                        //newsListView.BeginRefresh();
                        lessons = await LessonService.ShowByWeek(new() { Week = calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) });
                        foreach (var lesson in lessons)
                        {
                            if ((lesson.CourseNumber == prop.cource) && (lesson.Department == prop.department) && (lesson.Branch == prop.branch))
                            {
                                switch (lesson.DayOfWeek)
                                {
                                    case LessonDoWEnum.Mo:
                                        showlistMo.Add(new()
                                        {
                                            Where = lesson.Where,
                                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                            TimeStart = lesson.TimeStart,
                                            TimeEnd = lesson.TimeEnd,
                                        });
                                        break;
                                    case LessonDoWEnum.Tu:
                                        showlistTu.Add(new()
                                        {
                                            Where = lesson.Where,
                                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                            TimeStart = lesson.TimeStart,
                                            TimeEnd = lesson.TimeEnd,
                                        });
                                        break;
                                    case LessonDoWEnum.We:
                                        showlistWe.Add(new()
                                        {
                                            Where = lesson.Where,
                                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                            TimeStart = lesson.TimeStart,
                                            TimeEnd = lesson.TimeEnd,
                                        });
                                        break;
                                    case LessonDoWEnum.Th:
                                        showlistTh.Add(new()
                                        {
                                            Where = lesson.Where,
                                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                            TimeStart = lesson.TimeStart,
                                            TimeEnd = lesson.TimeEnd,
                                        });
                                        break;
                                    case LessonDoWEnum.Fr:
                                        showlistFr.Add(new()
                                        {
                                            Where = lesson.Where,
                                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                            TimeStart = lesson.TimeStart,
                                            TimeEnd = lesson.TimeEnd,
                                        });
                                        break;
                                    case LessonDoWEnum.Sa:
                                        showlistSa.Add(new()
                                        {
                                            Where = lesson.Where,
                                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                            TimeStart = lesson.TimeStart,
                                            TimeEnd = lesson.TimeEnd,
                                        });
                                        break;
                                    case LessonDoWEnum.Su:
                                        showlistSu.Add(new()
                                        {
                                            Where = lesson.Where,
                                            Description = $"{lesson.Name}, {lesson.Teacher}, {lesson.Extra}",
                                            TimeStart = lesson.TimeStart,
                                            TimeEnd = lesson.TimeEnd,
                                        });
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                        // newsListView.EndRefresh();
                        CourseChoiceSL.IsVisible = false;
                        DepartmentChoiceSL.IsVisible = false;
                        BranchChoiceSL.IsVisible = false;
                        ShowLessonsButton.IsVisible = false;

                        MondaySL.IsVisible = true;
                        TuesdaySL.IsVisible = true;
                        WednesdaySL.IsVisible = true;
                        ThursdaySL.IsVisible = true;
                        FridaySL.IsVisible = true;
                        SaturdaySL.IsVisible = true;
                        SundaySL.IsVisible = true;
                        MondayLessonsShowLV.ItemsSource = showlistMo;
                        TuesdayLessonsShowLV.ItemsSource = showlistTu;
                        WednesdayLessonsShowLV.ItemsSource = showlistWe;
                        ThursdayLessonsShowLV.ItemsSource = showlistTh;
                        FridayLessonsShowLV.ItemsSource = showlistFr;
                        SaturdayLessonsShowLV.ItemsSource = showlistSa;
                        SundayLessonsShowLV.ItemsSource = showlistSu;
                    });
                    


                    

                }
                else
                {
                    var toast = Toast.Make("Âûáåðèòå ñïåöèàëüíîñòü!", CommunityToolkit.Maui.Core.ToastDuration.Short);
                    toast.Show();
                }
            }
            else
            {
                var toast = Toast.Make("Âûáåðèòå îòäåëåíèå!", CommunityToolkit.Maui.Core.ToastDuration.Short);
                toast.Show();
            }
        }
        else
        {
            var toast = Toast.Make("Âûáåðèòå êóðñ!", CommunityToolkit.Maui.Core.ToastDuration.Short);
            toast.Show();
        }
    }

    private void MondayAddButton_Clicked(object sender, EventArgs e)
    {
        lesson.DayOfWeek = LessonDoWEnum.Mo;
        ScheduleShowVL.IsVisible = false;
        AddLessonVL.IsVisible = true;
        statusBar.StatusBarColor = Color.FromArgb("#242323");
    }

    private void TuesdayAdminButton_Clicked(object sender, EventArgs e)
    {
        lesson.DayOfWeek = LessonDoWEnum.Tu;
        ScheduleShowVL.IsVisible = false;
        AddLessonVL.IsVisible = true;
        statusBar.StatusBarColor = Color.FromArgb("#242323");
    }

    private void WednesdayAdminButton_Clicked(object sender, EventArgs e)
    {
        lesson.DayOfWeek = LessonDoWEnum.We;
        ScheduleShowVL.IsVisible = false;
        AddLessonVL.IsVisible = true;
    }

    private void ThursdayAdminButton_Clicked(object sender, EventArgs e)
    {
        lesson.DayOfWeek = LessonDoWEnum.Th;
        ScheduleShowVL.IsVisible = false;
        AddLessonVL.IsVisible = true;
        statusBar.StatusBarColor = Color.FromArgb("#242323");
    }

    private void FridayAdminButton_Clicked(object sender, EventArgs e)
    {
        lesson.DayOfWeek = LessonDoWEnum.Fr;
        ScheduleShowVL.IsVisible = false;
        AddLessonVL.IsVisible = true;
        statusBar.StatusBarColor = Color.FromArgb("#242323");
    }

    private void SaturdayAdminButton_Clicked(object sender, EventArgs e)
    {
        lesson.DayOfWeek = LessonDoWEnum.Sa;
        ScheduleShowVL.IsVisible = false;
        AddLessonVL.IsVisible = true;
        statusBar.StatusBarColor = Color.FromArgb("#242323");
    }

    private void SundayAdminButton_Clicked(object sender, EventArgs e)
    {
        lesson.DayOfWeek = LessonDoWEnum.Su;
        ScheduleShowVL.IsVisible = false;
        AddLessonVL.IsVisible = true;
        statusBar.StatusBarColor = Color.FromArgb("#242323");
    }

    private void BackArrowButton_Clicked(object sender, EventArgs e)
    {
        AddLessonVL.IsVisible = false;
        ScheduleShowVL.IsVisible = true;

        statusBar.StatusBarColor = Color.FromArgb("#8031A7");
    }

    private void StartButton_Clicked(object sender, EventArgs e)
    {
        if (ChoiceDoW.IsVisible)
        {
            ChoiceDoW.IsVisible = false;
            ChoiceStart.IsVisible = false;
        }
        else
        {
            ChoiceDoW.IsVisible = true;
            ChoiceStart.IsVisible = true;
        }
    }

    private void EndButton_Clicked(object sender, EventArgs e)
    {

    }

    private void DoWChoiceCV_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
        DayOfWeekN cur = e.CurrentItem as DayOfWeekN;
        DoWLabel.Text = cur.Name + ",";
    }

    private void StartChoiceCV_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
        LessonTime cur = e.CurrentItem as LessonTime;
        //cur_hour = cur.Time;
        StartLabel.Text = cur.Time;
    }

    private void StartMinuteChoiceCV_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
        LessonTime cur = e.CurrentItem as LessonTime;
        cur_minute = cur.Time;
        StartLabel.Text = cur_hour + ":" + cur_minute;
    }
}