using MiracleApp.Validation;
using MiracleApp.Services.Converters;
using MiracleApp.Services.News;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Converters;

namespace MiracleApp.Pages
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        ByteArrayToImageSourceConverter converter = new();
        byte[] newsPhoto;
        List<ShowNewsEntity> showList = new();

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
                
                NewsList.ItemsSource = showList;
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
            switch (count)
            {
                case 0:
                    {
                        frame4.IsVisible = true;
                        count++;
                    }
                    break;
                case 1:
                    {
                        frame3.IsVisible = true;
                        count++;
                    }
                    break;
                case 2:
                    {
                        frame1.IsVisible = true;
                        frame2.IsVisible = true;
                        frame3.IsVisible = false;
                        count++;
                    }
                    break;
                case 3:
                    {
                        frame1.IsVisible = false;
                        frame2.IsVisible = false;
                        frame3.IsVisible = false;
                        frame4.IsVisible = false;
                        count = 0;
                    }
                    break;
            }
        }

        private void addPhotoSmallNewsButton_Clicked(object sender, EventArgs e)
        {
            MainPageVS.IsVisible = false;
            AddNewsWithPhotoFrame.IsVisible = true;
        }

        private void addTextSmallNewsButton_Clicked(object sender, EventArgs e)
        {

        }

        private void addPhotoBigNewsButton_Clicked(object sender, EventArgs e)
        {
            MainPageVS.IsVisible = false;
            AddNewsWithPhotoFrame.IsVisible = true;
        }

        private void addTextBigNewsButton_Clicked(object sender, EventArgs e)
        {

        }

        private void CloseAddNewsButton_Clicked(object sender, EventArgs e)
        {
            MainPageVS.IsVisible = true;
            AddNewsWithPhotoFrame.IsVisible = false;
        }

        private async void AddNewsPhotoButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                newsPhoto = await ImageConverter.FileResultToByteArray(await MediaPicker.PickPhotoAsync());
                NewsPhotoButton.Source = converter.ConvertFrom(newsPhoto, null);  
                AddNewsPhotoButton.IsVisible = false;
                NewsPhotoButton.IsVisible = true;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
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
           if( newsPhoto.Length > 0 )
            {
                int newsId = await NewsServices.CreateNews(new()
                {
                    Name = "",
                    Content = NewsContentEntry.Text,
                    Image = Convert.ToBase64String(newsPhoto)
                });
                var toast = Toast.Make("", CommunityToolkit.Maui.Core.ToastDuration.Short);
                if (newsId > 0)
                    toast = Toast.Make("Новость успешно добавлена!", CommunityToolkit.Maui.Core.ToastDuration.Short);
                else
                    toast = Toast.Make("При добавлении новости произошла ошибка, повторите позже!", CommunityToolkit.Maui.Core.ToastDuration.Short);
                await toast.Show();
            }
           else
            {
               var toast = Toast.Make("Добавьте фото!", CommunityToolkit.Maui.Core.ToastDuration.Short);
                await toast.Show();
            }


        }

        private void SelectNewsButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private void NewsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is ShowNewsEntity selected_news)
            {
                var toast = Toast.Make(selected_news.Id.ToString(), CommunityToolkit.Maui.Core.ToastDuration.Short);
                toast.Show();
            }
        }
    }

    

}
