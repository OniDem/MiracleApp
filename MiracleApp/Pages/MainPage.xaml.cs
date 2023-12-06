
using Microsoft.Maui;

namespace MiracleApp.Pages
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BackgroundImage.Source = "background.png";
        }

        private async void SheduleButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SchedulePage());
        }
    }

}
