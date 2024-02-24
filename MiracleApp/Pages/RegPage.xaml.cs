using CommunityToolkit.Maui.Alerts;
using Core.Const;
using DTO.Users;
using MiracleApp.Services.Encrypt;
using MiracleApp.Services.User;
using MiracleApp.Validation;

namespace MiracleApp.Pages;

public partial class RegPage : ContentPage
{
    UserRoleEnum reg_role;
    CreateUserRequest reg_user = new();

    public RegPage()
    {
        if (UserValid.UserAuth())
        {
            Navigation.PushAsync(new MainPage());
        }
        InitializeComponent();
        BackButton.Source = "arrow.png";
        List<string> dep = new()
        {
            "Выберите отделение",
            "ЛО",
            "ЦК",
            "ТО",
            "КИТ"
        };
        List<string> stbranch = new()
             {
            "Выберите направление",
            "Реклама",
            "ИТ",
            "Дизайн",
            "Право",
            "Предпринимательво",
        };
        List<string> tebranch = new()
             {
            "Выберите специальность",
            "Стельба",
            "Английский язык",
            "Немецкий язык",
            "Изо",
            "Реклама",
        };
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
        DepartmentPicker.ItemsSource = dep;
        TeacherBranchPicker.ItemsSource = tebranch;
        StudentBranchPicker.ItemsSource = stbranch;
        DepartmentPicker.SelectedIndex = 0;
        TeacherBranchPicker.SelectedIndex = 0;
        StudentBranchPicker.SelectedIndex = 0;
    }

    private void CBSTeacher_CheckChanged(object sender, EventArgs e)
    {
        if (CBSTeacher.IsChecked)
        {
            CBStudent.IsChecked = false;
            reg_role = UserRoleEnum.Преподователь;
        }
    }

    private void CBStudent_CheckChanged(object sender, EventArgs e)
    {
        if (CBStudent.IsChecked)
        {
            CBSTeacher.IsChecked = false;
            reg_role = UserRoleEnum.Студент;
        }
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        if (VLChoiceRole.IsVisible == true)
        {
            Navigation.PopAsync();
            //Дописать очистку полей
        }
        if (VLStudentInfo.IsVisible == true)
        {
            VLStudentInfo.IsVisible = false;
            //Дописать очистку полей
            VLChoiceRole.IsVisible = true;
        }
        if (VLRegInfo.IsVisible == true)
        {
            VLRegInfo.IsVisible = false;
            //Дописать очистку полей
            VLStudentInfo.IsVisible = true;
        }
    }

    private void NextInfoButton_Clicked(object sender, EventArgs e)
    {
        if (CBStudent.IsChecked || CBSTeacher.IsChecked)
        {
            switch (reg_role)
            {
                case UserRoleEnum.Студент:
                    VLChoiceRole.IsVisible = false;
                    VLStudentInfo.IsVisible = true;
                    reg_user.Role = 0;
                    break;
                case UserRoleEnum.Преподователь:
                    VLChoiceRole.IsVisible = false;
                    VLTeacherInfo.IsVisible = true;
                    reg_user.Role = 1;
                    break;
            }
        }
        else
        {
            var toast = Toast.Make("Выберите кем продолжите регистрироваться", CommunityToolkit.Maui.Core.ToastDuration.Long);
            toast.Show();
        }
    }

    private void NextAuthButton_Clicked(object sender, EventArgs e)
    {
        switch (reg_role)
        {
            case UserRoleEnum.Студент:

                if (StudentFIOEntry.Text.Length > 0)
                {
                    if (CourseEntry.Text.Length > 0)
                    {
                        if (StudentBranchPicker.SelectedIndex != 0)
                        {
                            if (DepartmentPicker.SelectedIndex != 0)
                            {
                                VLStudentInfo.IsVisible = false;
                                VLRegInfo.IsVisible = true;
                                reg_user.FIO = StudentFIOEntry.Text;
                                reg_user.CourseNumber = CourseEntry.Text;
                                reg_user.StudentBranch = StudentBranchPicker.SelectedItem.ToString();
                                reg_user.Department = DepartmentPicker.SelectedItem.ToString();
                            }
                            else
                            {
                                var toast = Toast.Make("Выберите отделение обучения", CommunityToolkit.Maui.Core.ToastDuration.Long);
                                toast.Show();
                            }
                        }
                        else
                        {
                            var toast = Toast.Make("Выберите направление обучения", CommunityToolkit.Maui.Core.ToastDuration.Long);
                            toast.Show();
                        }
                    }
                    else
                    {
                        var toast = Toast.Make("Выберите свой курс", CommunityToolkit.Maui.Core.ToastDuration.Long);
                        toast.Show();
                    }
                }
                else
                {
                    var toast = Toast.Make("Введите ФИО", CommunityToolkit.Maui.Core.ToastDuration.Long);
                    toast.Show();
                }
                break;
            case UserRoleEnum.Преподователь:
                if (TeacherFIOEntry.Text.Length > 0)
                {
                    if (TeacherBranchPicker.SelectedIndex != 0)
                    {
                        VLTeacherInfo.IsVisible = false;
                        VLRegInfo.IsVisible = true;
                        reg_user.FIO = TeacherFIOEntry.Text;
                        reg_user.StudentBranch = TeacherBranchPicker.SelectedItem.ToString(); // Поменять на ветки препода(пока что для тестов)
                    }
                    else
                    {
                        var toast = Toast.Make("Выберите специальность", CommunityToolkit.Maui.Core.ToastDuration.Long);
                        toast.Show();
                    }
                }
                else
                {
                    var toast = Toast.Make("Введите ФИО", CommunityToolkit.Maui.Core.ToastDuration.Long);
                    toast.Show();
                }
                break;
        }
    }

    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        if (PhoneEntry.Text.Length > 0)
        {
            if (MailEntry.Text.Contains('@'))
            {
                if (PasswordEntry.Text.Length > 0)
                {
                    reg_user.Phone = PhoneEntry.Text;
                    reg_user.Email = MailEntry.Text;
                    reg_user.Password = Convert.ToBase64String(await EncryptService.EncryptStringToByteArrayAsync(PasswordEntry.Text));
                    reg_user.Photo = "";

                    if (await UserService.RegUser(reg_user) > 0)
                    {
                        await Navigation.PushAsync(new MainPage());
                        await DisplayAlert("Def Info", "Номер:" + reg_user.Phone + ", " + "ФИО:" + reg_user.FIO + ", " + "Роль:" + reg_user.Role + ", " + "Отделение:" + reg_user.Department + ", " + "Направление/Специальность:" + reg_user.StudentBranch + ", " + "Курс:" + reg_user.CourseNumber + ", " + "Пароль:" + reg_user.Password + "; " + "Отправьте разработчику для отладки!", "OK");
                    }
                    else
                    {
                        var toast = Toast.Make("При регистрации произошла ошибка! Попробуйте позже", CommunityToolkit.Maui.Core.ToastDuration.Long);
                        await toast.Show();
                    }
                }
                else
                {
                    var toast = Toast.Make("Введите пароль!", CommunityToolkit.Maui.Core.ToastDuration.Long);
                    await toast.Show();
                }
            }
            else
            {
                var toast = Toast.Make("Некорректная почта!", CommunityToolkit.Maui.Core.ToastDuration.Long);
                await toast.Show();
            }
        }
        else
        {
            var toast = Toast.Make("Введите номер телефона!", CommunityToolkit.Maui.Core.ToastDuration.Long);
            await toast.Show();
        }
    }
}