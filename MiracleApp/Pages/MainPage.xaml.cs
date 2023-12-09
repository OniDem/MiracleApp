
using Microsoft.Maui;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Buffers.Text;
using System.Net.Http;
using System;

namespace MiracleApp.Pages
{
    public partial class MainPage : ContentPage
    {

        private Frame CreateNews(string name, string content, string imageURL, Color color)
        {
            return new Frame
            {
                BorderColor = color,
                CornerRadius = 5,
                Padding = 10,
                BackgroundColor =  color,
                Content = new StackLayout
                    {
                        new Label
                        {
                            Text =  name,
                            FontSize = 20,
                            FontFamily = "QANELASREGULAR.TTF"
                        },
                        new Image
                        {
                            Source =  imageURL
                        },
                        new Label
                        {
                            Text = content,
                            FontFamily = "QANELASREGULAR.TTF",
                            FontSize = 15
                        }
                    }
            };

        }

        private async void GetNews()
        {

            string[] content = { "Ошибка", "Нет подключения к серверу", "dotnet_bot.svg", "60,180,60" };
            try
            {
                string serverURI = "http://192.168.100.3:8080/";
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(serverURI);

                
                if (response.IsSuccessStatusCode)
                {
                    content = (await response.Content.ReadAsStringAsync()).Split('^');
                }
                string[] colorValues = content[3].Split(',');
                Color color = new Color(Convert.ToInt16(colorValues[0]), Convert.ToInt16(colorValues[1]), Convert.ToInt16(colorValues[2]));
                NewsLayout.Children.Add(CreateNews(content[0], content[1], content[2], color));
            }
            catch(Exception exeption)
            {
                NewsLayout.Children.Add(CreateNews("Ошибка", exeption.Message, content[2], new Color(255,0,0)));
            }   
        }

        public MainPage()
        {
            InitializeComponent();
            SettingsButton.Source = "settings.png";
            HomeButton.Source = "home.png";
            ProfileButton.Source = "profile.png";
            NotificationButton.Source = "notification.png";

            //string content = "Л";
            GetNews();
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
