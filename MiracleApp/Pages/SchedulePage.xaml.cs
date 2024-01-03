using Core.Const;
using Core.Entity;
using MiracleApp.Services.Lesson;
using MiracleApp.Validation;

namespace MiracleApp.Pages;

public partial class SchedulePage : ContentPage
{
    LessonEntity lesson = new LessonEntity
    {
        Name = "œÓ„‡ÏÏËÓ‚‡ÌËÂ",
        Date = "",
        TimeStart = DateTime.Now.ToShortTimeString(),
        TimeEnd = DateTime.Now.AddMinutes(90).ToShortTimeString(),
        DayOfWeek = LessonDoWEnum.Su,
        TeacherFIO = "»‚‡ÌÓ‚ »‚‡Ì »‚‡ÌÓ‚Ë˜",
        CourseNumber = "3",
        Department = DepartmentEnum.ÀŒ,
    };

    LessonEntity lesson1 = new LessonEntity
    {
        Name = "ƒËÁ‡ÈÌ",
        Date = "",
        TimeStart = DateTime.Now.ToShortTimeString(),
        TimeEnd = DateTime.Now.AddMinutes(90).ToShortTimeString(),
        DayOfWeek = LessonDoWEnum.Su,
        TeacherFIO = "»‚‡ÌÓ‚ »‚‡Ì »‚‡ÌÓ‚Ë˜",
        CourseNumber = "1",
        Department = DepartmentEnum.ÀŒ,
    };

    LessonEntity lesson2 = new LessonEntity
    {
        Name = "»ÁÓ",
        Date = "",
        TimeStart = DateTime.Now.ToShortTimeString(),
        TimeEnd = DateTime.Now.AddMinutes(90).ToShortTimeString(),
        DayOfWeek = LessonDoWEnum.Su,
        TeacherFIO = "»‚‡ÌÓ‚ »‚‡Ì »‚‡ÌÓ‚Ë˜",
        CourseNumber = "1",
        Department = DepartmentEnum.ÀŒ,
    };

    LessonEntity lesson3 = new LessonEntity
    {
        Name = "œÓÚÓÚËÔËÓ‚‡ÌËÂ",
        Date = "",
        TimeStart = DateTime.Now.ToShortTimeString(),
        TimeEnd = DateTime.Now.AddMinutes(90).ToShortTimeString(),
        DayOfWeek = LessonDoWEnum.Su,
        TeacherFIO = "»‚‡ÌÓ‚ »‚‡Ì »‚‡ÌÓ‚Ë˜",
        CourseNumber = "1",
        Department = DepartmentEnum.ÀŒ,
    };

    public SchedulePage()
    {
        if (!UserValid.UserAuth())
        {
            Navigation.PushAsync(new HelloPage());
        }
        InitializeComponent();
        BackButton.Source = "backbutton.png";
        NextButton.Source = "backbutton.png";

        //testLayout.Add(LessonService.ShowLesson(lesson));
        //testLayout.Add(LessonService.ShowLesson(lesson1));
        //testLayout.Add(LessonService.ShowLesson(lesson2));
        //testLayout.Add(LessonService.ShowLesson(lesson3));
    }

    private async void MainButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
        MainButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        ScheduleButton.BackgroundColor = Colors.Transparent;
        PayButton.BackgroundColor = Colors.Transparent;
        —ertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void ScheduleButton_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new SchedulePage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        PayButton.BackgroundColor = Colors.Transparent;
        —ertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void PayButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PayPage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Colors.Transparent;
        PayButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        —ertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void —ertificateButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CertificatePage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Colors.Transparent;
        PayButton.BackgroundColor = Colors.Transparent;
        —ertificateButton.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void CourceOneButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#1E1E1E");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceFourButton.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void CourceTwoButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#1E1E1E");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceFourButton.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void CourceThreeButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#1E1E1E");
        CourceFourButton.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void CourceFourButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceFourButton.BackgroundColor = Color.FromArgb("#1E1E1E");
    }

    private void Department1_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Department2_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Department3_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Department4_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Department5_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#1E1E1E");
    }

    private void Branch1_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Branch2_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Branch3_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Branch4_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Branch5_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Branch6_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#1E1E1E");
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void NextButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PayPage());
    }

    private void ShowLessonButton_Clicked(object sender, EventArgs e)
    {

    }

    //private void test_Clicked(object sender, EventArgs e)
    //{
    //    switch (Lesson.IsVisible)
    //    {
    //        case true:
    //            Lesson.IsVisible = false;
    //            break;

    //        case false:
    //            Lesson.IsVisible = true;
    //            break;
    //    }
    //}


}