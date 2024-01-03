using MiracleApp.Validation;

namespace MiracleApp.Pages;

public partial class CertificatePage : ContentPage
{
    public CertificatePage()
    {
        if (!UserValid.UserAuth())
        {
            Navigation.PushAsync(new HelloPage());
        }
        InitializeComponent();
        BackButton.Source = "backbutton.png";
    }

    private async void MainButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
        MainButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        ScheduleButton.BackgroundColor = Colors.Transparent;
        PayButton.BackgroundColor = Colors.Transparent;
        ÑertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void ScheduleButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new SchedulePage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        PayButton.BackgroundColor = Colors.Transparent;
        ÑertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void PayButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new PayPage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Colors.Transparent;
        PayButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        ÑertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void ÑertificateButton_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushModalAsync(new CertificatePage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Colors.Transparent;
        PayButton.BackgroundColor = Colors.Transparent;
        ÑertificateButton.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PayPage());
    }
}