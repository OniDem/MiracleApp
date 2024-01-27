using CommunityToolkit.Maui.Views;
using MiracleApp.Services.News;
using MiracleApp.Validation;

namespace MiracleApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            if (!UserValid.UserAuth())
            {
                Navigation.PushAsync(new HelloPage());
            }
            InitializeComponent();
            SettingsButton.Source = "settings.svg";
            HomeButton.Source = "home_selected.svg";
            ProfileButton.Source = "profile.svg";
            NotificationButton.Source = "notification.svg";
            Dispatcher.Dispatch(async () =>
            {
                //newsListView.BeginRefresh();
               // newsListView.ItemsSource = await NewsServices.ShowAll();
                // newsListView.EndRefresh();
            });
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
            var popup = new LoadingPage();
            this.ShowPopup(popup);
            await Task.Delay(5000);
            popup.Close();
            //await Navigation.PushAsync(new SettingsPage());
        }


        private void HomeButton_Clicked(object sender, EventArgs e)
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
