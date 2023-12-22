using Core.Entity;
using Newtonsoft.Json;

namespace MiracleApp.Pages
{
    public partial class MainPage : ContentPage
    {

        async Task<List<NewsEntity>> ShowAll()
        {
            string serverURI = "http://45.153.69.204:5000/News/ShowAll";
            HttpClient client = new HttpClient();
            Dictionary<string, string> Params = new()
            {

            };
            FormUrlEncodedContent content = new(Params);
            HttpResponseMessage response = await client.PostAsync(serverURI, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<NewsEntity>>(result);
            }
            return null;
        }

        public MainPage()
        {
            InitializeComponent();
            SettingsButton.Source = "settings.png";
            HomeButton.Source = "home.png";
            ProfileButton.Source = "profile.png";
            NotificationButton.Source = "notification.png";
            Dispatcher.Dispatch(async() =>
            {
                //newsListView.BeginRefresh();
                newsListView.ItemsSource = await ShowAll();
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
