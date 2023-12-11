using MiracleApp.Const;

namespace MiracleApp.Convertor
{
    static class Converter
    {
        public static string UserRoleConvertor(UserRoleEnum roleEnum)
        {
            switch (roleEnum)
            {
                case UserRoleEnum.Administrator:
                    return "Администратор";
                case UserRoleEnum.Student:
                    return "Студент";
                case UserRoleEnum.Teacher:
                    return "Преподователь";
                case UserRoleEnum.Combo:
                    return "Преподователь, Студент";
                default:
                    return "";
            }
        }

        public static string StudentBranchConvertor(StudentBranchEnum branchEnum)
        {
            switch (branchEnum)
            {
                case StudentBranchEnum.Marketing:
                    return "Реклама и маркетинг";
                case StudentBranchEnum.It:
                    return "Информационные технологии";
                case StudentBranchEnum.Social:
                    return "Социо-культурная деятельность";
                case StudentBranchEnum.Law:
                    return "Право и судебное администрирование";
                case StudentBranchEnum.Enterprise:
                    return "Предпринимательство";
                case StudentBranchEnum.Design:
                    return "Дизайн";
                default:
                    return "";
            }
        }

        public static string DepartmentConvertor(DepartmentEnum depEnum)
        {
            switch (depEnum)
            {
                case DepartmentEnum.ЦК:
                    return "ЦК";
                case DepartmentEnum.ЛО:
                    return "ЛО";
                case DepartmentEnum.КИТ:
                    return "КИТ";
                case DepartmentEnum.БО:
                    return "БО";
                case DepartmentEnum.ТО:
                    return "ТО";
                default:
                    return "";
            }
        }
    }
}
