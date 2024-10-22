using CommunityToolkit.Maui.Behaviors;
using MiracleApp.Validation;

namespace MiracleApp.Pages;

public partial class NotificationsPage : ContentPage
{

    StatusBarBehavior statusBar = new();
    public NotificationsPage()
    {
        if (!UserValid.UserAuth())
        {
            Navigation.PushAsync(new HelloPage());
        }
        InitializeComponent();
        SettingsButton.Source = "settings.svg";
        HomeButton.Source = "home.svg";
        ProfileButton.Source = "profile.svg";
        NotificationButton.Source = "notification.svg";
    }

    private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
        statusBar.StatusBarColor = Color.FromArgb("#242323");
    }

    private async void HomeButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void ProfileButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());
    }

    private async void NotificationButton_Clicked(object sender, EventArgs e)
    {
    }
}