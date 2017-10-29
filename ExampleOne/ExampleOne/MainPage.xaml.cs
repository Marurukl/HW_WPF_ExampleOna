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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage(string login)
        {
            InitializeComponent();
            dataBase = new DataBase();
            dataBase.readFromFile();
            this.login = login;
            byte redByte, greenByte, blueByte;
            for (int i = 0; i < dataBase.login.Count; i++)
            {
                if(login == dataBase.login[i])
                {
                    redByte = Convert.ToByte(dataBase.red[i]);
                    greenByte = Convert.ToByte(dataBase.green[i]);
                    blueByte = Convert.ToByte(dataBase.blue[i]);
                    grid.Background = new SolidColorBrush(Color.FromRgb(redByte, greenByte, blueByte));
                }
            }
        }
        DataBase dataBase;
        string login;
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte red, blue, green;
            red = Convert.ToByte(redSlider.Value);
            blue = Convert.ToByte(blueSlider.Value);
            green = Convert.ToByte(greenSlider.Value);
            grid.Background = new SolidColorBrush(Color.FromRgb(red, green, blue));
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            dataBase.changeBG(login, redSlider.Value, greenSlider.Value, blueSlider.Value);
            dataBase.saveInFile();
        }
    }
}
