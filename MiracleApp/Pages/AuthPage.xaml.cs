using CommunityToolkit.Maui.Alerts;
using DTO.Users;
using MiracleApp.Services.User;
using MiracleApp.Validation;

namespace MiracleApp.Pages;

public partial class AuthPage : ContentPage
{
    string super_secret_code = "123456";
    public AuthPage()
    {
        if (UserValid.UserAuth())
        {
            Navigation.PushAsync(new MainPage());
        }
        InitializeComponent();
        BackButton.Source = "arrow.png";
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
        if (PhoneEntry.Text.Length > 0)
        {
            if (PasswordEntry.Text.Length > 0)
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
                    var toast = Toast.Make("��� ����� ��������� ������!", CommunityToolkit.Maui.Core.ToastDuration.Long);
                    await toast.Show();
                }
            }
            else
            {
                var toast = Toast.Make("������� ������", CommunityToolkit.Maui.Core.ToastDuration.Long);
                await toast.Show();
            }
        }
        else
        {
            var toast = Toast.Make("������� ����� ��������", CommunityToolkit.Maui.Core.ToastDuration.Long);
            await toast.Show();
        }
    }

    private void ForegotPasswordButton_Clicked(object sender, EventArgs e)
    {
        AuthSL.IsVisible = false;
        RestoreSL.IsVisible = true;
    }

    private void GetCodeButton_Clicked(object sender, EventArgs e)
    {
        if (EmailEntry.Text.Contains("@"))
        {
            RestoreSL.IsVisible = false;
            VerifySL.IsVisible = true;
        }
        else
        {
            var toast = Toast.Make("�� �������� ������!", CommunityToolkit.Maui.Core.ToastDuration.Long);
            toast.Show();
        }
    }

    private void ConfirmButtun_Clicked(object sender, EventArgs e)
    {
        var code = Code1Entry.Text + Code2Entry.Text + Code3Entry.Text + Code4Entry.Text + Code5Entry.Text + Code6Entry.Text;
        if (code.Length == 6)
        {
            if(code == super_secret_code)
            {
                VerifySL.IsVisible = false;
                NewPasswordSL.IsVisible = true;
            }
            else
            {
                var toast = Toast.Make("��� �� �����! �� ��� �������� :)", CommunityToolkit.Maui.Core.ToastDuration.Long);
                toast.Show();
            }
        }
        else
        {
            var toast = Toast.Make("��� ����� �� ��������!", CommunityToolkit.Maui.Core.ToastDuration.Long);
            toast.Show();
        }
    }

    private void Code1Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length == Code1Entry.MaxLength)
        {
            Code2Entry.Focus();
        }
        
    }

    private void Code2Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length == Code2Entry.MaxLength)
        {
            Code3Entry.Focus();
        }
        if (e.NewTextValue.Length == 0)
        {
            Code1Entry.Focus();
        }
    }

    private void Code3Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length == Code4Entry.MaxLength)
        {
            Code4Entry.Focus();
        }
        if (e.NewTextValue.Length == 0)
        {
            Code2Entry.Focus();
        }
    }

    private void Code4Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length == Code4Entry.MaxLength)
        {
            Code5Entry.Focus();
        }
        if (e.NewTextValue.Length == 0)
        {
            Code3Entry.Focus();
        }
    }

    private void Code5Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length == Code5Entry.MaxLength)
        {
            Code6Entry.Focus();
        }
        if (e.NewTextValue.Length == 0)
        {
            Code4Entry.Focus();
        }
    }

    private void Code6Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.NewTextValue.Length == 0)
        {
            Code5Entry.Focus();
        }
    }

    private async void NewPasswordButton_Clicked(object sender, EventArgs e)
    {
        if(NewPassword.Text.Length > 0 && ConfirmNewPassword.Text.Length > 0)
        {
            if(NewPassword.Text == ConfirmNewPassword.Text)
            {
                //�������� ������ �� ����� �� ��������(����� ��������� � ���������� ������!)
                //var user = await UserService.GetUserById(new() { id = Convert.ToInt32(await SecureStorage.GetAsync("id")) });
                //UpdateUserRequest entity = new()
                //{
                //    Phone = user.Phone,
                //    FIO = user.FIO,
                //    Role = user.Role,
                //    Department = user.Department,
                //    StudentBranch = user.StudentBranch,
                //    CourseNumber = user.CourseNumber,
                //    Password = NewPassword.Text
                //};
                //if (await UserService.UpdateUser(user.Id, entity))
                //{
                //    var toast = Toast.Make("������ ������� �������!", CommunityToolkit.Maui.Core.ToastDuration.Long);
                //    toast.Show();
                NewPasswordSL.IsVisible = false;
                AuthSL.IsVisible = true;
                //}
                //else
                //{
                //    var toast = Toast.Make("��� ������ ������ ��������� ������!", CommunityToolkit.Maui.Core.ToastDuration.Long);
                //    toast.Show();
                //}
            }
            else
            {
                var toast = Toast.Make("������ ������ ���������", CommunityToolkit.Maui.Core.ToastDuration.Long);
                toast.Show();
            }
        }
        else
        {
            var toast = Toast.Make("����� ������ ������ ���� ������ ����", CommunityToolkit.Maui.Core.ToastDuration.Long);
            toast.Show();
        }
    }
}