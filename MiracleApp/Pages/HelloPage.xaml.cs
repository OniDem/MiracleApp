using MiracleApp.Validation;

namespace MiracleApp.Pages;

public partial class HelloPage : ContentPage
{
    public HelloPage()
    {
        var stack = Shell.Current.Navigation.NavigationStack.ToArray();
        for (int i = stack.Length - 1; i > 0; i--)
        {
            Shell.Current.Navigation.RemovePage(stack[i]);
        }
        if (UserValid.UserAuth())
        {
            Navigation.PushAsync(new MainPage());
        }
        InitializeComponent();

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