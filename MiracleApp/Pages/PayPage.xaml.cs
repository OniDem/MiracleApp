using MiracleApp.Validation;

namespace MiracleApp.Pages;

public partial class PayPage : ContentPage
{
    public PayPage()
    {
        if (!UserValid.UserAuth())
        {
            Navigation.PushAsync(new HelloPage());
        }
        InitializeComponent();
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
        await Navigation.PushAsync(new SchedulePage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        PayButton.BackgroundColor = Colors.Transparent;
        ÑertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void PayButton_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new PayPage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Colors.Transparent;
        PayButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        ÑertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void ÑertificateButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CertificatePage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Colors.Transparent;
        PayButton.BackgroundColor = Colors.Transparent;
        ÑertificateButton.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SchedulePage());
    }

    private async void NextButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CertificatePage());
    }
}