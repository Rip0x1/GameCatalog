using System;
using System.Windows;
using WpfApp1.Services;

namespace WpfApp1
{
    public partial class LoginWindow : Window
    {
        private DatabaseService _dbService;

        public event Action<int> UserAuthenticated;

        public LoginWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                string password = PasswordBox.Password;
                name.Trim();
                password.Trim();

                if (name == "admin" && password == "admin")
                {
                    AdminWindow adminWindow = new AdminWindow();
                    int userID = _dbService.GetUserIdByName(name);
                    GamesListWindow gamesListWindow = new GamesListWindow(_dbService, userID);
                    adminWindow.ShowDialog();
                }
                else if (_dbService.AuthenticateUser(name, password))
                {
                    StatusTextBlock.Visibility = Visibility.Collapsed;
                    int currentUserId = _dbService.GetUserIdByName(name);
                    UserAuthenticated?.Invoke(currentUserId);
                    Close();
                }
                else
                {
                    StatusTextBlock.Text = "Неверное имя пользователя или пароль.";
                    StatusTextBlock.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Произошла ошибка: " + ex.Message;
                StatusTextBlock.Visibility = Visibility.Visible;
            }
        }
    }
}
