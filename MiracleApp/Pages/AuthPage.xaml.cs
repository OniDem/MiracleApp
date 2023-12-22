using MiracleApp.Validation;

namespace MiracleApp.Pages;

public partial class AuthPage : ContentPage
{
	public AuthPage()
	{
		InitializeComponent();
        if(UserValid.UserAuth(false))
        {
            Navigation.PushAsync(new MainPage());
        }
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}