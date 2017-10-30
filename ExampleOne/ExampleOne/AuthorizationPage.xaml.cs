using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExampleOne
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        DataBase dataBase;
        public AuthorizationPage()
        {
            InitializeComponent();
            dataBase = new DataBase();
            dataBase.ReadFromFile();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataBase.CheckUser(loginTextBox.Text, errorLabel.Content))
            {
               (this.Parent as MainWindow).NavigationService.Navigate(new MainPage(loginTextBox.Text));
            }
            else
            {
                errorLabel.Content= "Неправльный Логин!";
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as MainWindow).NavigationService.Navigate(new RegistrationPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            dataBase.ReadFromFile();
        }
    }
}
