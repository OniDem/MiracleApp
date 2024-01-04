using CommunityToolkit.Maui.Alerts;
using Core.Entity;
using MiracleApp.Services.User;
using MiracleApp.Validation;

namespace MiracleApp.Pages;

public partial class ProfilePage : ContentPage
{
    public UserEntity user = new();

    public ProfilePage()
    {
        if (!UserValid.UserAuth())
        {
            Navigation.PushAsync(new HelloPage());
        }
        Dispatcher.Dispatch(async () =>
        {
            UserInfoVL.BindingContext = await UserService.GetUserById(new() { id = Convert.ToInt32(await SecureStorage.GetAsync("id")) });
        });
        InitializeComponent();
        SettingsButton.Source = "settings.svg";
        HomeButton.Source = "home.svg";
        ProfileButton.Source = "profile_selected.svg";
        NotificationButton.Source = "notification.svg";
        LogOut.Source = "logout.svg";
        ProfileEdit.Source = "prodile_edit.svg";

    }

    private async void SettingsButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
    }

    private async void HomeButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void ProfileButton_Clicked(object sender, EventArgs e)
    {

    }

    private async void NotificationButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NotificationsPage());
    }

    private void LogOut_Clicked(object sender, EventArgs e)
    {
        SecureStorage.RemoveAll();
        Navigation.PushAsync(new HelloPage());
    }

    private void ProfileEdit_Clicked(object sender, EventArgs e)
    {
        var toast = Toast.Make("Данная кнопка в разработке!", CommunityToolkit.Maui.Core.ToastDuration.Long);
        toast.Show();
    }
}