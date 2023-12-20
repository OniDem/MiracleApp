using Core.Entity;
using System.ComponentModel;

namespace MiracleApp.ViewModel
{
    class UserViewModel
    {
        int id;
        string username;
        string role;
        string course;

        public int ID
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(id));
            }
        }
        public string UserName
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(username));
            }
        }

        public string Role
        {
            get => role;
            set
            {
                role = value;
                OnPropertyChanged(nameof(role));
            }
        }

        public string Course
        {
            get => course;
            set
            {
                course = value;
                OnPropertyChanged(nameof(course));
            }
        }

        public UserViewModel()
        {
            id = -1;
            username = "Пользователь не авторизован";
            role = "Пользователь не авторизован";
            course = "Пользователь не авторизован";
        }


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
