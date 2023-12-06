namespace MiracleApp.Pages;

public partial class SchedulePage : ContentPage
{
	public SchedulePage()
	{
		
		InitializeComponent();
        BackgroundImage.Source = "background.png";
		BackButton.Source = "backbutton.png";
        NextButton.Source = "backbutton.png";
    }

    private async void MainButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
        MainButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        ScheduleButton.BackgroundColor = Colors.Transparent;
        PayButton.BackgroundColor = Colors.Transparent;
        ÑertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void ScheduleButton_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new SchedulePage());
        MainButton.BackgroundColor = Colors.Transparent;
        ScheduleButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        PayButton.BackgroundColor = Colors.Transparent;
        ÑertificateButton.BackgroundColor = Colors.Transparent;
    }

    private async void PayButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PayPage());
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

    private void CourceOneButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#1E1E1E");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceFourButton.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void CourceTwoButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#1E1E1E");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceFourButton.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void CourceThreeButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#1E1E1E");
        CourceFourButton.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void CourceFourButton_Clicked(object sender, EventArgs e)
    {
        CourceOneButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceTwoButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceThreeButton.BackgroundColor = Color.FromArgb("#9F5CC0");
        CourceFourButton.BackgroundColor = Color.FromArgb("#1E1E1E");
    }

    private void Department1_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Department2_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Department3_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Department4_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#1E1E1E");
        Department5.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Department5_Clicked(object sender, EventArgs e)
    {
        Department1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Department5.BackgroundColor = Color.FromArgb("#1E1E1E");
    }

    private void Branch1_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Branch2_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Branch3_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Branch4_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Branch5_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#1E1E1E");
        Branch6.BackgroundColor = Color.FromArgb("#9F5CC0");
    }

    private void Branch6_Clicked(object sender, EventArgs e)
    {
        Branch1.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch2.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch3.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch4.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch5.BackgroundColor = Color.FromArgb("#9F5CC0");
        Branch6.BackgroundColor = Color.FromArgb("#1E1E1E");
    }

    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void NextButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PayPage());
    }
}