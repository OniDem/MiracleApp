namespace MiracleApp.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        SettingsButton.Source = "settings.png";
        HomeButton.Source = "home.png";
        ProfileButton.Source = "profile.png";
        NotificationButton.Source = "notification.png";
    }

    private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
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
        await Navigation.PushAsync(new NotificationsPage());
    }
}