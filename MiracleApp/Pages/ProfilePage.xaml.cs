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
        new("Криминалогия.", "ПН.", "9:00", true),
        new("Криминалогия.", "ПН.", "10:00", false),
        new("Криминалогия.", "ПН.", "11:00", true),
        new("Криминалогия.", "ПН.", "12:00", false),
        new("Криминалогия.", "ПН.", "13:00", false),
        new("Криминалогия.", "ПН.", "18:00", true),
        

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
        user.UserName = "Илон Макс";
        user.Role = new() { "Преподователь", "Студент" };
        user.Course = "3 курс";

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