
using Microsoft.Maui;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Buffers.Text;
using System.Net.Http;
using System;

namespace MiracleApp.Pages
{
    public partial class MainPage : ContentPage
    {


        private int newsLoad = 0;
        public MainPage()
        {
            InitializeComponent();
            SettingsButton.Source = "settings.png";
            HomeButton.Source = "home.png";
            ProfileButton.Source = "profile.png";
            NotificationButton.Source = "notification.png";

            for(int i = 0; i < 3; i++) 
            {
                GetNews();
                NewsScrollLayout.ForceLayout();
            }
            
        }


        private async void OnScrollViewScrolled(object sender, ScrolledEventArgs e)
        {
            ScrollView scrollView = (ScrollView)sender;

            double contentHeight = scrollView.ContentSize.Height;
            double scrollViewHeight = scrollView.Height;
            double scrollPosition = e.ScrollY;
            double offset = 75;
            //DebugLabel.Text = contentHeight.ToString() + " " + scrollViewHeight.ToString() + " " + scrollPosition.ToString();
            if (scrollPosition + scrollViewHeight >= contentHeight-offset)
            {
                for (int i = 0; i < 3; i++)
                {
                    await GetNews();
                }
            }
        }
        private Frame CreateNews(string name, string content, string imageURL, Color color)
        {
            return new Frame
            {
                BorderColor = color,
                CornerRadius = 5,
                Padding = 10,
                BackgroundColor = color,
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
                            Source =  imageURL,
                            MaximumWidthRequest = 150
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


        private async Task GetNews()
        {
            //Условный код означающий что все новости которые впринципе есть загружены
            if (newsLoad == -1)
            {   

                return;
            }
            newsLoad++;
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string[] content = new string[3];
                    string serverURI = "http://192.168.100.3:8080/news/";
                    HttpResponseMessage response = await client.GetAsync(serverURI + newsLoad.ToString());
                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        //условная строка обозначающая что новости с таким индексом нету
                        if (data == "_end_")
                        {
                            newsLoad = -1;
                            return;
                        }
                        content = data.Split(';');
                        string[] colorValues = content[2].Split(',');
                        Color color = new Color(Convert.ToInt16(colorValues[0]), Convert.ToInt16(colorValues[1]), Convert.ToInt16(colorValues[2]));
                        NewsLayout.ItemsSource = new Frame[] { CreateNews(content[0], content[1], serverURI + "image/" + newsLoad.ToString(), color) };
                    }
                }
            }
            catch (Exception exeption)
            {
                NewsLayout.ItemsSource = new Frame[] { CreateNews("Ошибка", exeption.Message, "dotnet_bot.svg", new Color(255, 0, 0)) };
                //NewsLayout.Children.Add(CreateNews("Ошибка", exeption.Message, "dotnet_bot.svg", new Color(255, 0, 0)));
            }
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
