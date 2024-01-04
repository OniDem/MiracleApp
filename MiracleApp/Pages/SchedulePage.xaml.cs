using CommunityToolkit.Maui.Alerts;
using Core.Const;
using Core.Entity;
using MiracleApp.Services.Lesson;
using MiracleApp.Validation;

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
public partial class SchedulePage : ContentPage
{
    LessonShowProperties prop = new();

    public SchedulePage()
    {
        if (!UserValid.UserAuth())
        {
            Navigation.PushAsync(new HelloPage());
        }
        InitializeComponent();
        MondaySL.IsVisible = false;
        TuesdaySL.IsVisible = false;
        WednesdaySL.IsVisible = false;
        ThursdaySL.IsVisible = false;
        FridaySL.IsVisible = false;
        SaturdaySL.IsVisible = false;
        SundaySL.IsVisible = false;
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
        prop.cource = "1";
    }

    private void CourceTwoButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#1E1E1E");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceFourButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.cource = "2";
    }

    private void CourceThreeButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#1E1E1E");
        CourceFourButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.cource = "3";
    }

    private void CourceFourButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceFourButton.BackgroundColor = Color.FromArgb("#1E1E1E");
        prop.cource = "4";
    }

    private void Department1_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.department = "1";
    }

    private void Department2_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.department = "2";
    }

    private void Department3_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.department = "3";
    }

    private void Department4_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");
        prop.department = "4";
    }

    private void Department5_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#1E1E1E");
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
                        lessons = await LessonService.ShowAll();
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


}