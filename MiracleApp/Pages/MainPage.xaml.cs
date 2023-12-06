
namespace MiracleApp.Pages
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void SheduleButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SchedulePage());
        }
    }

}
