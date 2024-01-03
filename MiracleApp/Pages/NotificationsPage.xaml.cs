using MiracleApp.Validation;

namespace MiracleApp.Pages;

public partial class NotificationsPage : ContentPage
{
    public NotificationsPage()
    {
        if (!UserValid.UserAuth())
        {
            Navigation.PushAsync(new HelloPage());
        }
        InitializeComponent();
        SettingsButton.Source = "settings.png";
        HomeButton.Source = "home.png";
        ProfileButton.Source = "profile.png";
        NotificationButton.Source = "notification.png";
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
        await Navigation.PushAsync(new ProfilePage());
    }

    private async void NotificationButton_Clicked(object sender, EventArgs e)
    {
    }
}