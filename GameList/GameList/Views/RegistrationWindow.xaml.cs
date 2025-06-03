using System.Windows;
using System.Windows.Controls;
using WpfApp1.Services;

namespace WpfApp1
{
    public partial class RegistrationWindow : Window
    {
        private DatabaseService _dbService;

        public RegistrationWindow()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                string password = PasswordBox.Password;


                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
                {
                    if (_dbService.RegisterUser(name.Trim(), password.Trim()))
                    {
                        MessageBox.Show("Вы успешно зарегистрировались!");
                        int userId = _dbService.GetUserIdByName(name);
                        GamesListWindow gamesListWindow = new GamesListWindow(_dbService, userId);
                        gamesListWindow.Show();
                        Close();
                    }
                    else if (name == "admin")
                    {
                        StatusTextBlock1.Text = "Ошибка регистрации.";
                        StatusTextBlock2.Text = "Имя пользователя уже существует. Попробуйте другое имя.";
                        StatusTextBlock1.Visibility = Visibility.Visible;
                        StatusTextBlock2.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        StatusTextBlock1.Text = "Ошибка регистрации.";
                        StatusTextBlock2.Text = "Введите данные для входа";
                        StatusTextBlock1.Visibility = Visibility.Visible;
                        StatusTextBlock2.Visibility = Visibility.Visible;
                    }
                }

                else 
                {
                    StatusTextBlock1.Text = "Ошибка регистрации.";
                    StatusTextBlock2.Text = "Имя пользователя уже существует. Попробуйте другое имя.";
                    StatusTextBlock1.Visibility = Visibility.Visible;
                    StatusTextBlock2.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
