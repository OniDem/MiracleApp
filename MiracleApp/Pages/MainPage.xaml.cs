
using Microsoft.Maui;

namespace MiracleApp.Pages
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            SettingsButton.Source = "settings.png";
            HomeButton.Source = "home.png";
            ProfileButton.Source = "profile.png";
            NotificationButton.Source = "notification.png";
        }

        private async void SheduleButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SchedulePage());
        }
        private async void CertificateButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CertificatePage());
        }
        private async void PayButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PayPage());
        }

        private async void MainButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void SettingsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void HomeButton_Clicked(object sender, EventArgs e)
        {
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

}
