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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
            dataBase = new DataBase();
            dataBase.readFromFile();
        }
        DataBase dataBase;
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte red, blue, green;
            red = Convert.ToByte(redSlider.Value);
            blue = Convert.ToByte(blueSlider.Value);
            green = Convert.ToByte(greenSlider.Value);
            grid.Background = new SolidColorBrush(Color.FromRgb(red,green,blue));
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginTextBox.Text))
            {
                for (int i = 0; i < dataBase.login.Count; i++)
                {
                    if (dataBase.login[i] != loginTextBox.Text)
                    {
                        dataBase.AddUser(loginTextBox.Text, redSlider.Value, greenSlider.Value, blueSlider.Value);
                        (this.Parent as MainWindow).NavigationService.Navigate(new AuthorizationPage());
                        dataBase.saveInFile();
                    }
                    else
                    {
                        errorLabel.Content = "Неправльный Логин!";
                    }
                }
            }
            else
            {
                MessageBox.Show("Пустой логин");
            }
        }
    }
}
