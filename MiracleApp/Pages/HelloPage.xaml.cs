using MiracleApp.Validation;

namespace MiracleApp.Pages;

public partial class HelloPage : ContentPage
{
	public HelloPage()
	{
		InitializeComponent();
        if(UserValid.UserAuth(false))
        {
            Navigation.PushAsync(new MainPage());
        }
	}

    private void Auth_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AuthPage());
    }

    private void Register_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegPage());
    }
}