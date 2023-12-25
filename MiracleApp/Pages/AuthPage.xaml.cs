using MiracleApp.Validation;
using MiracleApp.Services.User;
using CommunityToolkit.Maui.Alerts;

namespace MiracleApp.Pages;

public partial class AuthPage : ContentPage
{
	public AuthPage()
	{
        if (UserValid.UserAuth())
        {
            Navigation.PushAsync(new MainPage());
        }
        InitializeComponent();
        BackButton.Source = "backbutton.png";
        PhoneEntry.TextChanged += (s, e) =>
        {
            if (e.NewTextValue.Length >= PhoneEntry.Mask.Length)
            {
                PhoneEntry.CursorPosition = PhoneEntry.Mask.Length;
            }
            else
            {
                PhoneEntry.CursorPosition = e.NewTextValue.Length;
            }
        };
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private async void AuthButton_Clicked(object sender, EventArgs e)
    {
        if(PhoneEntry.Text.Length > 0)
        {
            if(PasswordEntry.Text.Length > 0)
            {
                if (await UserService.AuthUser(new() { Phone = PhoneEntry.Text, Password = PasswordEntry.Text }))
                {
                    var id = await SecureStorage.Default.GetAsync("id");
                    var token = await SecureStorage.Default.GetAsync("token");
                    //await DisplayAlert("Dev info", "id:" + id + ", " + "token:" + token, "OK");
                    await Navigation.PushAsync(new MainPage());
                }
                else
                {
                    var toast = Toast.Make("При входе произошла ошибка!", CommunityToolkit.Maui.Core.ToastDuration.Long);
                    await toast.Show();
                }
            }
            else
            {
                var toast = Toast.Make("Введите пароль", CommunityToolkit.Maui.Core.ToastDuration.Long);
                await toast.Show();
            }
        }
        else
        {
            var toast = Toast.Make("Введите номер телефона", CommunityToolkit.Maui.Core.ToastDuration.Long);
            await toast.Show();
        }
    }

    private void ForegotPasswordButton_Clicked(object sender, EventArgs e)
    {
        //Сделать восстановление пароля
        var toast = Toast.Make("Не забывайте пароль)", CommunityToolkit.Maui.Core.ToastDuration.Long);
        toast.Show();
    }
}