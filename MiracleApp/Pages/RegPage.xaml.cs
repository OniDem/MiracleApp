using CommunityToolkit.Maui.Alerts;
using Core.Const;
using Core.Entity;
using DTO.Users;
using System.Net.Http.Json;

namespace MiracleApp.Pages;

public partial class RegPage : ContentPage
{
    UserRoleEnum reg_role;
    CreateUserRequest reg_user = new();

	public RegPage()
	{
		InitializeComponent();
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
        if(CBSTeacher.IsChecked)
        {
            CBStudent.IsChecked = false;
            reg_role = UserRoleEnum.Teacher;
        }
    }

    private void CBStudent_CheckChanged(object sender, EventArgs e)
    {
        if(CBStudent.IsChecked)
        {
            CBSTeacher.IsChecked = false;
            reg_role = UserRoleEnum.Student;
        }
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        if(VLChoiceRole.IsVisible == true)
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
        if(VLRegInfo.IsVisible == true)
        {
            VLRegInfo.IsVisible = false;
            //Дописать очистку полей
            VLStudentInfo.IsVisible = true;
        }
    }

    private void NextInfoButton_Clicked(object sender, EventArgs e)
    {
        if(CBStudent.IsChecked || CBSTeacher.IsChecked)
        {
            switch (reg_role)
            {
                case UserRoleEnum.Student:
                    VLChoiceRole.IsVisible = false;
                    VLStudentInfo.IsVisible = true;
                    reg_user.Role = UserRoleEnum.Student;
                    break;
                case UserRoleEnum.Teacher:
                    VLChoiceRole.IsVisible = false;
                    VLTeacherInfo.IsVisible = true;
                    reg_user.Role = UserRoleEnum.Teacher;
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
            case UserRoleEnum.Student:

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
            case UserRoleEnum.Teacher:
                if(TeacherFIOEntry.Text.Length > 0)
                {
                    if (TeacherBranchPicker.SelectedIndex != 0)
                    {
                        VLTeacherInfo.IsVisible = false;
                        VLRegInfo.IsVisible = true;
                        reg_user.FIO = TeacherFIOEntry.Text;
                        reg_user.StudentBranch = TeacherBranchPicker.SelectedItem.ToString(); // Поменять на ветки препода(пока то для тестов)
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
        if(PhoneEntry.Text.Length > 0)
        {
            if(PasswordEntry.Text.Length > 0)
            {
                reg_user.Phone = PhoneEntry.Text;
                reg_user.Password = PasswordEntry.Text;

                if (await RegUSer(reg_user) > 0)
                {
                    await Navigation.PushAsync(new MainPage());
                    await DisplayAlert("Def Info", "Номер:" + reg_user.Phone + ", " + "ФИО:" + reg_user.FIO + ", " + "Роль:" + reg_user.Role + ", " + "Отделение:" + reg_user.Department + ", " + "Направление/Специальность:" + reg_user.StudentBranch + ", " + "Курс:" + reg_user.CourseNumber + ", " + "Пароль:" + reg_user.Password + "; " + "Отправьте разработчику для отладки!", "OK");
                }
                else
                {
                    await DisplayAlert("Def Info", "Номер:" + reg_user.Phone + ", " + "ФИО:" + reg_user.FIO + ", " + "Роль:" + reg_user.Role + ", " + "Отделение:" + reg_user.Department + ", " + "Направление/Специальность:" + reg_user.StudentBranch + ", " + "Курс:" + reg_user.CourseNumber + ", " + "Пароль:" + reg_user.Password + "; " + "Отправьте разработчику для отладки!", "OK");
                    var toast = Toast.Make("При регистрации произошла ошибка! Попробуйте позже", CommunityToolkit.Maui.Core.ToastDuration.Long);
                    toast.Show();
                }
            }
            else
            {
                var toast = Toast.Make("Введите пароль", CommunityToolkit.Maui.Core.ToastDuration.Long);
                toast.Show();
            }
        }
        else
        {
            var toast = Toast.Make("Введите номер телефона", CommunityToolkit.Maui.Core.ToastDuration.Long);
            toast.Show();
        }
    }

    private async Task<int> RegUSer(CreateUserRequest entity)
    {
        if(entity.Role == UserRoleEnum.Teacher)
        {
            reg_user.CourseNumber = "";
            reg_user.Department = "";
        }
        JsonContent content = JsonContent.Create(entity);
        HttpClient httpClient = new HttpClient();
        var response = await httpClient.PostAsync("http://45.153.69.204:5000/User/Create", content);
        var registered_user = await response.Content.ReadFromJsonAsync<UserEntity>();
        await DisplayAlert("Def Info","Ответ сервера:"+ response.StatusCode + ", " + "ИД:" + registered_user.Id + ", " + "Номер:" + registered_user.Phone + ", " + "ФИО:" + registered_user.FIO + ", " + "Роль:" + registered_user.Role + ", " + "Отделение:" + registered_user.Department + ", " + "Направление/Специальность:" + registered_user.StudentBranch + ", " + "Курс:" + registered_user.CourseNumber + ", " + "Пароль:" + registered_user.Password + "; " + "Отправьте разработчику для отладки!", "OK");
        return registered_user.Id;
    }
}