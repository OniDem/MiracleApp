using Core.Const;

namespace MiracleApp.Pages;

public partial class RegPage : ContentPage
{
    UserRoleEnum reg_role;
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

        List<string> lessons = new()
        {
            "Выберите направление",
            "ЛФК",
            "Китайский язый",
            "Немецкий язык",
            "Криминалистика"
        };
        DepartmentPicker.ItemsSource = dep;
        BranchPicker.ItemsSource = lessons;
        DepartmentPicker.SelectedIndex = 0;
        BranchPicker.SelectedIndex = 0;
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
        switch (reg_role)
        {
            case UserRoleEnum.Student:
                VLChoiceRole.IsVisible = false;
                VLStudentInfo.IsVisible = true;
                break;
            case UserRoleEnum.Teacher:
                VLChoiceRole.IsVisible = false;
                VLTeacherInfo.IsVisible = true;
                break;
        }
    }

    private void NextAuthButton_Clicked(object sender, EventArgs e)
    {
        switch (reg_role)
        {
            case UserRoleEnum.Student:
                if (DepartmentPicker.SelectedIndex != 0)
                {
                    VLStudentInfo.IsVisible = false;
                    VLRegInfo.IsVisible = true;
                }
                break;
            case UserRoleEnum.Teacher:
                if (BranchPicker.SelectedIndex != 0)
                {
                    VLTeacherInfo.IsVisible = false;
                    VLRegInfo.IsVisible = true;
                }
                break;
        }
    }

    private void RegisterButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}