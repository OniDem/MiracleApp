using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Behaviors;
using DTO.Users;
using MiracleApp.Services.User;
using MiracleApp.Validation;
using System.Windows.Input;

namespace MiracleApp.Pages;

public partial class SettingsPage : ContentPage
{
    StatusBarBehavior statusBar = new();
    bool notificationToggle;

    public SettingsPage()
    {
        
        if (!UserValid.UserAuth())
        {
            Navigation.PushAsync(new HelloPage());
        }
        InitializeComponent();
        SettingsButton.Source = "settings_selected.svg";
        HomeButton.Source = "home.svg";
        ProfileButton.Source = "profile.svg";
        NotificationButton.Source = "notification.svg";
        BackArrowButton.Source = "arrow.svg";
        CloseProfileEditButton.Source = "arrow.svg";



    }

    private void SettingsButton_Clicked(object sender, EventArgs e)
    {

    }

    private async void HomeButton_Clicked(object sender, EventArgs e)
    {
        if(await DisplayAlert("Вы уверены?", "Не сохранённые данные будут утеряны!", "Ок", "Отмена"))
        {
            await Navigation.PushAsync(new MainPage());
            statusBar.StatusBarColor = Color.FromArgb("#8031A7");
        }
        
    }

    private async void ProfileButton_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Вы уверены?", "Не сохранённые данные будут утеряны!", "Ок", "Отмена"))
        {
            await Navigation.PushAsync(new ProfilePage());
            statusBar.StatusBarColor = Color.FromArgb("#8031A7");
        }
        
    }

    private async void NotificationButton_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Вы уверены?", "Не сохранённые данные будут утеряны!", "Ок", "Отмена"))
        {
            await Navigation.PushAsync(new NotificationsPage());
            statusBar.StatusBarColor = Color.FromArgb("#8031A7");
        }
        
    }

    private void ProfileEditTap_Tapped(object sender, TappedEventArgs e)
    {
        EditProfileSV.IsVisible = true;
        SettingsSV.IsVisible = false;
        Dispatcher.Dispatch(async () =>
        {
            var user = await UserService.GetUserById(new() { id = Convert.ToInt32(await SecureStorage.GetAsync("id")) });
            FIOEntry.Text = user.FIO;
            CourceNumberEntry.Text = user.CourseNumber;
            StudentBrachEntry.Text = user.StudentBranch;
        });
    }

    private void ToggleNotificationTap_Tapped(object sender, TappedEventArgs e)
    {
        
        if (ToggleNotificationLabel.Text == "Вкл.")
        {
            ToggleNotificationLabel.Text = "Выкл.";
            notificationToggle = false;
        }
        else
        {
            ToggleNotificationLabel.Text = "Вкл.";
            notificationToggle = true;
        }
        var toast = Toast.Make(notificationToggle.ToString(), CommunityToolkit.Maui.Core.ToastDuration.Short);
        toast.Show();
    }

    private void OpenRulesTap_Tapped(object sender, TappedEventArgs e)
    {
        var toast = Toast.Make("rules", CommunityToolkit.Maui.Core.ToastDuration.Short);
        toast.Show();
    }

    private void ScheduleEditTap_Tapped(object sender, TappedEventArgs e)
    {
        var toast = Toast.Make("schedule", CommunityToolkit.Maui.Core.ToastDuration.Short);
        toast.Show();
    }

    private void ShowPostsTap_Tapped(object sender, TappedEventArgs e)
    {
        var toast = Toast.Make("posts", CommunityToolkit.Maui.Core.ToastDuration.Short);
        toast.Show();
    }

    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        //Save all changes

        Navigation.PushAsync(new MainPage());
        statusBar.StatusBarColor = Color.FromArgb("#8031A7");
    }

    private async void BackArrowButton_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Вы уверены?", "Не сохранённые данные будут утеряны!", "Ок", "Отмена"))
        {
            await Navigation.PushAsync(new MainPage());
            statusBar.StatusBarColor = Color.FromArgb("#8031A7");
        }
        
    }

    private async void CloseProfileEditButton_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("Вы уверены?", "Не сохранённые данные будут утеряны!", "Ок", "Отмена"))
        {
            EditProfileSV.IsVisible = false;
            SettingsSV.IsVisible = true;
        }
    }

    private void SaveProfileButton_Clicked(object sender, EventArgs e)
    {
        Dispatcher.Dispatch(async () =>
        {
            var user = await UserService.GetUserById(new() { id = Convert.ToInt32(await SecureStorage.GetAsync("id")) });
            UpdateUserRequest entity = new()
            {
                Phone = user.Phone,
                Email = user.Email,
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
                await toast.Show();
            }
            else
            {
                var toast = Toast.Make("При изменении данных произошла ошибка", CommunityToolkit.Maui.Core.ToastDuration.Long);
                await toast.Show();
            }
        });
        EditProfileSV.IsVisible = false;
        SettingsSV.IsVisible = true;
    }
}