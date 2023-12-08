using MiracleApp.Entity;
using System.Collections.ObjectModel;

namespace MiracleApp.Pages;

public partial class ProfilePage : ContentPage
{
    class Tab
    {
        public string LessonName { get; set; }

        public string LessonDate { get; set; }

        public string LessonTime { get; set; }

        public bool IsChecked { get; set; }

        public Tab(string name, string date, string time, bool @checked)
        {
            LessonName = name;
            LessonDate = date;
            LessonTime = time;
            IsChecked = @checked;
        }
    }

    List<Tab> tabs = new()
    {
        new("������������.", "��.", "9:00", true),
        new("������������.", "��.", "10:00", false),
        new("������������.", "��.", "11:00", true),
        new("������������.", "��.", "12:00", false),
        new("������������.", "��.", "13:00", false),
        new("������������.", "��.", "18:00", true),
        

    };

    UserEntity user = new();
    

    public ProfilePage()
	{
        InitializeComponent();
        SettingsButton.Source = "settings.png";
        HomeButton.Source = "home.png";
        ProfileButton.Source = "profile.png";
        NotificationButton.Source = "notification.png";
        Dispatcher.Dispatch(async () =>
        {
            await Task.Run(() => ListViewTest.ItemsSource = tabs);
        });
        user.UserName = "���� ����";
        user.Role = new() { "�������������", "�������" };
        user.Course = "3 ����";

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