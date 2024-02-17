using MiracleApp.Validation;
using MiracleApp.Services.Converters;
using MiracleApp.Services.News;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Converters;
using MiracleApp.Entity;

namespace MiracleApp.Pages
{
    public partial class MainPage : ContentPage
    {
        ByteArrayToImageSourceConverter converter = new();
        byte[] newsPhoto;
        string newsType;
        ShowNewsEntity CurrentNews = new();

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
                if (await SecureStorage.GetAsync("role") == "3")
                {
                    addNewsButton.Source = "add_news_button.svg";
                    addNewsButton.IsVisible = true;
                }
                else
                {
                    
                }
            });

            Dispatcher.Dispatch(async () =>
            {
                NewsList.ItemsSource = await NewsServices.ShowAll();
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
            //var popup = new LoadingPage();
            //this.ShowPopup(popup);
            //await Task.Delay(5000);
            //popup.Close();
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

        private void addNewsButton_Clicked(object sender, EventArgs e)
        {
            if(addNewsFrame.IsVisible)
                addNewsFrame.IsVisible = false;
            else
                addNewsFrame.IsVisible = true;
        }

        private void addPhotoNewsButton_Clicked(object sender, EventArgs e)
        {
            newsType = "media";
            if (AddPhotoToNewsFrame.IsVisible)
                AddPhotoToNewsFrame.IsVisible = false;
            else
                AddPhotoToNewsFrame.IsVisible = true;
        }

        private void addTextNewsButton_Clicked(object sender, EventArgs e)
        {
            newsType = "text";
            if (AddPhotoToNewsFrame.IsVisible)
                AddPhotoToNewsFrame.IsVisible = false;
            else
                AddPhotoToNewsFrame.IsVisible = true;
        }

        private void CloseAddNewsButton_Clicked(object sender, EventArgs e)
        {
            MainPageVS.IsVisible = true;
            AddNewsWithPhotoFrame.IsVisible = false;
            NewsMainContextFrame.IsVisible = false;
            AddedNewsPhotoButton.Source = converter.ConvertFrom(newsPhoto, null);
        }

        private void NewsPhotoButton_Clicked(object sender, EventArgs e)
        {
            if (ChoiceNewsPhotoButton.IsVisible)
                ChoiceNewsPhotoButton.IsVisible = false;
            else
                ChoiceNewsPhotoButton.IsVisible = true;
        }

        private void ChoiceNewPhotoButton_Clicked(object sender, EventArgs e)
        {
            //In Work
        }

        private async void ChoiceGalleryPhotoButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                newsPhoto = await ImageConverter.FileResultToByteArray(await MediaPicker.PickPhotoAsync());
                NewsPhotoButton.Source = converter.ConvertFrom(newsPhoto, null);
                ChoiceNewsPhotoButton.IsVisible = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void SaveFullNewsButton_Clicked(object sender, EventArgs e)
        {
            var toast = Toast.Make("Новость добавляется...", CommunityToolkit.Maui.Core.ToastDuration.Long);
            await toast.Show();
            Dispatcher.Dispatch(async () =>
            {
                int newsId = 0;
                newsId = await NewsServices.CreateNews(new()
                {
                    Name = "",
                    Content = NewsContentEntry.Text,
                    Image = Convert.ToBase64String(newsPhoto)
                });


                if (newsId > 0)
                {

                    toast = Toast.Make("Новость успешно добавлена!", CommunityToolkit.Maui.Core.ToastDuration.Short);
                    MainPageVS.IsVisible = true;
                    AddNewsWithPhotoFrame.IsVisible = false;
                    NewsMainContextFrame.IsVisible = false;
                    newsPhoto = null;
                    AddedNewsPhotoButton.IsVisible = false;
                    AddedNewsPhotoButton.Source = null;
                    AddPhotoToNewsFrame.IsVisible = false;
                    NewsList.ItemsSource = await NewsServices.ShowAll();
                }
                else
                    toast = Toast.Make("При добавлении новости произошла ошибка, повторите позже!", CommunityToolkit.Maui.Core.ToastDuration.Short);
                await toast.Show();
            });
        }
        //Work!!!
        private void NewsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (SelectedNewsFrame.IsVisible)
            { 
                SelectedNewsFrame.IsVisible = false; 
                MainPageVS.IsVisible = true;
            }
            else
            {
                SelectedNewsFrame.IsVisible = true;
                MainPageVS.IsVisible = false;
                if (e.SelectedItem is ShowNewsEntity selected_news)
                {
                    CurrentNews = selected_news;
                    SelectedNewsImage.Source = selected_news.Image;
                    SelectedNewsContent.Text = selected_news.Content;
                    var toast = Toast.Make(selected_news.Id.ToString(), CommunityToolkit.Maui.Core.ToastDuration.Short);
                    toast.Show();
                }
            }
            
        }

        private  void AddPhotoToNewsButton_Clicked(object sender, EventArgs e)
        {
            Dispatcher.Dispatch(async() =>
            {
                    newsPhoto ??= await ImageConverter.FileResultToByteArray(await MediaPicker.PickPhotoAsync());

                AddedNewsPhotoButton.Source = converter.ConvertFrom(newsPhoto, null);
                AddedNewsPhotoButton.IsVisible = true;
                if (newsType == "text")
                {
                    NewsPhotoButton.Source = converter.ConvertFrom(newsPhoto, null);
                    MainPageVS.IsVisible = false;
                    AddNewsWithPhotoFrame.IsVisible = true;
                }
            });
            
        }

        private void AddedNewsPhotoButton_Clicked(object sender, EventArgs e)
        {
            if (NewsMainContextFrame.IsVisible)
                NewsMainContextFrame.IsVisible = false;
            else
                NewsMainContextFrame.IsVisible = true;
        }

        private void ChoiceNewPhotoToNewsButton_Clicked(object sender, EventArgs e)
        {
            Dispatcher.Dispatch(async () =>
            {
                newsPhoto = await ImageConverter.FileResultToByteArray(await MediaPicker.PickPhotoAsync());
                AddedNewsPhotoButton.Source = converter.ConvertFrom(newsPhoto, null);
            });
        }

        private void AddTextToNewsButton_Clicked(object sender, EventArgs e)
        {
            MainPageVS.IsVisible = false;
            AddNewsWithPhotoFrame.IsVisible = true;
            NewsPhotoButton.Source = converter.ConvertFrom(newsPhoto, null);
        }

        private void CloseSelectedNewsButton_Clicked(object sender, EventArgs e)
        {
            SelectedNewsFrame.IsVisible = false;
            MainPageVS.IsVisible = true;
        }

        private void DeleteSelectedNewsButton_Clicked(object sender, EventArgs e)
        {
            Dispatcher.Dispatch(async () =>
            {
                if (await NewsServices.DeleteNews(new() { Id = CurrentNews.Id }))
                {
                    NewsList.ItemsSource = await NewsServices.ShowAll();
                    SelectedNewsFrame.IsVisible = false;
                    MainPageVS.IsVisible = true;
                    var toast = Toast.Make("Новость успешно удалена!", CommunityToolkit.Maui.Core.ToastDuration.Short);
                    toast.Show();
                }
                else
                {
                    var toast = Toast.Make("При удалении новости произошла ошибка!", CommunityToolkit.Maui.Core.ToastDuration.Short);
                    toast.Show();
                }
            });      
        }
    }

    

}
