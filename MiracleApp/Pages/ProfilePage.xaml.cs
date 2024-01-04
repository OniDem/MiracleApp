using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Behaviors;
using Core.Entity;
using DTO.Users;
using MiracleApp.Services.User;
using MiracleApp.Validation;

namespace MiracleApp.Pages;

public partial class ProfilePage : ContentPage
{
    StatusBarBehavior statusBar = new();

    public ProfilePage()
    {
        if (!UserValid.UserAuth())
        {
            Navigation.PushAsync(new HelloPage());
        }
        Dispatcher.Dispatch(async () =>
        {
            var user = await UserService.GetUserById(new() { id = Convert.ToInt32(await SecureStorage.GetAsync("id")) });
            UserInfoVL.BindingContext = user;
        });
        InitializeComponent();
        SettingsButton.Source = "settings.svg";
        HomeButton.Source = "home.svg";
        ProfileButton.Source = "profile_selected.svg";
        NotificationButton.Source = "notification.svg";
        LogOutSure.Source = "logout.svg";
        ProfileEdit.Source = "prodile_edit.svg";
        MiniCancelButton.Source = "mini_cancel.svg";
        BackArrowButton.Source = "arrow.svg";

        statusBar.StatusBarColor = Color.FromArgb("#8031A7");
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


    private void ProfileEdit_Clicked(object sender, EventArgs e)
    {
        MainProfileSV.IsVisible = false;
        statusBar.StatusBarColor = Color.FromArgb("#242323");
        EditProfileSV.IsVisible = true;
        Dispatcher.Dispatch(async () =>
        {
            var user = await UserService.GetUserById(new() { id = Convert.ToInt32(await SecureStorage.GetAsync("id")) });
            FIOEntry.Text = user.FIO;
            CourceNumberEntry.Text = user.CourseNumber;
            StudentBrachEntry.Text = user.StudentBranch;
        });
        
    }

    private void LogOutSure_Clicked(object sender, EventArgs e)
    {
        LogOutFrame.IsVisible = true;
    }

    private void LogOut_Clicked(object sender, EventArgs e)
    {
        SecureStorage.RemoveAll();
        Navigation.PushAsync(new HelloPage());
    }

    private void CancelButton_Clicked(object sender, EventArgs e)
    {
        LogOutFrame.IsVisible = false;
    }

    private void MiniCancelButton_Clicked(object sender, EventArgs e)
    {
        LogOutFrame.IsVisible = false;
    }

    private void BackArrowButton_Clicked(object sender, EventArgs e)
    {
        EditProfileSV.IsVisible = false;
        statusBar.StatusBarColor = Color.FromArgb("#8031A7");
        MainProfileSV.IsVisible = true;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        Dispatcher.Dispatch(async () =>
        {
            var user = await UserService.GetUserById(new() { id = Convert.ToInt32(await SecureStorage.GetAsync("id")) });
            UpdateUserRequest entity = new()
            {
                Phone = user.Phone,
                FIO = FIOEntry.Text,
                Role = user.Role,
                Department = user.Department,
                StudentBranch = StudentBrachEntry.Text,
                CourseNumber = CourceNumberEntry.Text,
                Password = user.Password
            };
            if (await UserService.UpdateUser(user.Id, entity))
            {
                var toast = Toast.Make("Данные успешно изменены!", CommunityToolkit.Maui.Core.ToastDuration.Long);
                toast.Show();
                UserInfoVL.BindingContext = user;
            }
            else
            {
                var toast = Toast.Make("При изменении данных произошла ошибка", CommunityToolkit.Maui.Core.ToastDuration.Long);
                toast.Show();
            }
        });
        
         
    }
}