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
            "�������� ���������",
            "��",
            "��",
            "��",
            "���"
        };
        List<string> stbranch = new()
             {
            "�������� �����������",
            "�������",
            "��",
            "������",
            "�����",
            "�����������������",
        };
        List<string> tebranch = new()
             {
            "�������� �������������",
            "�������",
            "���������� ����",
            "�������� ����",
            "���",
            "�������",
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
            //�������� ������� �����
        }
        if (VLStudentInfo.IsVisible == true)
        {
            VLStudentInfo.IsVisible = false;
            //�������� ������� �����
            VLChoiceRole.IsVisible = true;
        }
        if(VLRegInfo.IsVisible == true)
        {
            VLRegInfo.IsVisible = false;
            //�������� ������� �����
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
            var toast = Toast.Make("�������� ��� ���������� ����������������", CommunityToolkit.Maui.Core.ToastDuration.Long);
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
                                var toast = Toast.Make("�������� ��������� ��������", CommunityToolkit.Maui.Core.ToastDuration.Long);
                                toast.Show();
                            }
                        }
                        else
                        {
                            var toast = Toast.Make("�������� ����������� ��������", CommunityToolkit.Maui.Core.ToastDuration.Long);
                            toast.Show();
                        }
                    }
                    else
                    {
                        var toast = Toast.Make("�������� ���� ����", CommunityToolkit.Maui.Core.ToastDuration.Long);
                        toast.Show();
                    }
                }
                else
                {
                    var toast = Toast.Make("������� ���", CommunityToolkit.Maui.Core.ToastDuration.Long);
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
                        reg_user.StudentBranch = TeacherBranchPicker.SelectedItem.ToString(); // �������� �� ����� �������(���� �� ��� ������)
                    }
                    else
                    {
                        var toast = Toast.Make("�������� �������������", CommunityToolkit.Maui.Core.ToastDuration.Long);
                        toast.Show();
                    }
                }
                else
                {
                    var toast = Toast.Make("������� ���", CommunityToolkit.Maui.Core.ToastDuration.Long);
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
                    await DisplayAlert("Def Info", "�����:" + reg_user.Phone + ", " + "���:" + reg_user.FIO + ", " + "����:" + reg_user.Role + ", " + "���������:" + reg_user.Department + ", " + "�����������/�������������:" + reg_user.StudentBranch + ", " + "����:" + reg_user.CourseNumber + ", " + "������:" + reg_user.Password + "; " + "��������� ������������ ��� �������!", "OK");
                }
                else
                {
                    await DisplayAlert("Def Info", "�����:" + reg_user.Phone + ", " + "���:" + reg_user.FIO + ", " + "����:" + reg_user.Role + ", " + "���������:" + reg_user.Department + ", " + "�����������/�������������:" + reg_user.StudentBranch + ", " + "����:" + reg_user.CourseNumber + ", " + "������:" + reg_user.Password + "; " + "��������� ������������ ��� �������!", "OK");
                    var toast = Toast.Make("��� ����������� ��������� ������! ���������� �����", CommunityToolkit.Maui.Core.ToastDuration.Long);
                    toast.Show();
                }
            }
            else
            {
                var toast = Toast.Make("������� ������", CommunityToolkit.Maui.Core.ToastDuration.Long);
                toast.Show();
            }
        }
        else
        {
            var toast = Toast.Make("������� ����� ��������", CommunityToolkit.Maui.Core.ToastDuration.Long);
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
        await DisplayAlert("Def Info","����� �������:"+ response.StatusCode + ", " + "��:" + registered_user.Id + ", " + "�����:" + registered_user.Phone + ", " + "���:" + registered_user.FIO + ", " + "����:" + registered_user.Role + ", " + "���������:" + registered_user.Department + ", " + "�����������/�������������:" + registered_user.StudentBranch + ", " + "����:" + registered_user.CourseNumber + ", " + "������:" + registered_user.Password + "; " + "��������� ������������ ��� �������!", "OK");
        return registered_user.Id;
    }
}