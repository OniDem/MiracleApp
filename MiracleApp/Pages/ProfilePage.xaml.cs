using MiracleApp.Entity;
using MiracleApp.ViewModel;

namespace MiracleApp.Pages;

public partial class ProfilePage : ContentPage
{
    StudentLessonEntity lesson1 = new()
    {
        Lesson_id = 1,
        Lesson_name = "�������� �����������������",
        Lesson_date = "��.",
        Lesson_time = "11:11",
        Lesson_course = "����� � �������� �����������������",
        Lesson_choised = true,
        Lesson_teacher_id = 2
    };
    StudentLessonEntity lesson2 = new()
    {
        Lesson_id = 1,
        Lesson_name = "������������",
        Lesson_date = "��.",
        Lesson_time = "9:00",
        Lesson_course = "����� � �������� �����������������",
        Lesson_choised = true,
        Lesson_teacher_id = 2
    };
    StudentLessonEntity lesson3 = new()
    {
        Lesson_id = 1,
        Lesson_name = "��������",
        Lesson_date = "��.",
        Lesson_time = "10:00",
        Lesson_course = "����� � �������� �����������������",
        Lesson_choised = false,
        Lesson_teacher_id = 3
    };
    StudentLessonEntity lesson4 = new()
    {
        Lesson_id = 1,
        Lesson_name = "�����",
        Lesson_date = "��.",
        Lesson_time = "11:00",
        Lesson_course = "�����",
        Lesson_choised = false,
        Lesson_teacher_id = 4
    };

    StudentMarkEntity mark1 = new()
    {
        Mark = 1,
        Student_id = 1,
        Teacher_id = 4,
        Course = "��������"
    };
    StudentMarkEntity mark2 = new()
    {
        Mark = 3,
        Student_id = 1,
        Teacher_id = 4,
        Course = "����� � �������� �����������������"
    };
    StudentMarkEntity mark3 = new()
    {
        Mark = 9,
        Student_id = 1,
        Teacher_id = 4,
        Course = "������������"
    };
    StudentMarkEntity mark4 = new()
    {
        Mark = 10,
        Student_id = 1,
        Teacher_id = 4,
        Course = "�������� �����������������"
    };



    List<StudentLessonEntity> lessons = new();
    List<StudentMarkEntity> marks = new();

    UserEntity user = new()
    {
        Id = 1,
        UserName = "���� ����",
        Role = "�������������, " + "�������",
        Course = "�����"
    };
    UserViewModel userView = new();


    public ProfilePage()
	{
        InitializeComponent();
        SettingsButton.Source = "settings.png";
        HomeButton.Source = "home.png";
        ProfileButton.Source = "profile.png";
        NotificationButton.Source = "notification.png";

        if (user.Id > 0)
            userView = new(user);
        lessons.Add(lesson1);
        lessons.Add(lesson2);
        lessons.Add(lesson3);
        lessons.Add(lesson4);
        lessons.Add(lesson1);
        lessons.Add(lesson2);
        lessons.Add(lesson3);
        lessons.Add(lesson4);
        marks.Add(mark1);
        marks.Add(mark2);
        marks.Add(mark3);
        marks.Add(mark4);

        Dispatcher.Dispatch(async () =>
        {
            await Task.Run(() => ListViewTest.ItemsSource = lessons);
            await Task.Run(() => ListViewMarks.ItemsSource = marks);
            BindingContext = userView;
        });
    }

    private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
    }

    private async void HomeButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void ProfileButton_Clicked(object sender, EventArgs e)
    {
    }

    private async void NotificationButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NotificationsPage());
    }

    
}