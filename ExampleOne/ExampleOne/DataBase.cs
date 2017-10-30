using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExampleOne
{
    public class DataBase
    {
        public List<string> login = new List<string>();
        public List<double> red = new List<double>(), green = new List<double>(), blue = new List<double>();
        private string pathLogin = "userLogin.txt";
        private string pathRed = "userRed.txt";
        private string pathGreen = "userGreen.txt";
        private string pathBlue = "userBlue.txt";
        public void AddUser(string login, double red, double green, double blue)
        {
            this.login.Add(login);
            this.red.Add(red);
            this.green.Add(green);
            this.blue.Add(blue);
        }
        public void ChangeBG(string login, double red, double green, double blue)
        {
            for (int i = 0; i < this.login.Count; i++)
            {
                if (this.login[i] == login)
                {
                    this.red[i] = red;
                    this.green[i] = green;
                    this.blue[i] = blue;
                }
            }
        }
        public void ReadFromFile()
        {
            
            string dataLogin, dataRed, dataGreen, dataBlue;
            string[] login, red, green, blue;
            double white = 254.9;
            string admin = "Admin";
            int whiteLenght = 5 , adminLenght=5;

            try
            {
                FileStream fsLogin = new FileStream(pathLogin, FileMode.Open);
                FileStream fsRed = new FileStream(pathRed, FileMode.Open);
                FileStream fsGreen = new FileStream(pathGreen, FileMode.Open);
                FileStream fsBlue = new FileStream(pathBlue, FileMode.Open);

                byte[] bytesLogin = new byte[fsLogin.Length];
                byte[] bytesRed = new byte[fsLogin.Length];
                byte[] bytesGreen = new byte[fsLogin.Length];
                byte[] bytesBlue = new byte[fsLogin.Length];

                fsLogin.Read(bytesLogin, 0, bytesLogin.Length);
                fsRed.Read(bytesRed, 0, bytesRed.Length);
                fsGreen.Read(bytesGreen, 0, bytesGreen.Length);
                fsBlue.Read(bytesBlue, 0, bytesBlue.Length);

                dataLogin = Encoding.ASCII.GetString(bytesLogin);
                dataRed = Encoding.ASCII.GetString(bytesRed);
                dataGreen = Encoding.ASCII.GetString(bytesGreen);
                dataBlue = Encoding.ASCII.GetString(bytesBlue);

                login = dataLogin.Split(';');
                red = dataRed.Split(';');
                green = dataGreen.Split(';');
                blue = dataBlue.Split(';');

                login[login.Length - 1] = login[login.Length - 1].TrimEnd(' ');
                red[red.Length - 1] = red[red.Length - 1].TrimEnd(' ');
                green[green.Length - 1] = green[green.Length - 1].TrimEnd(' ');
                blue[blue.Length - 1] = blue[blue.Length - 1].TrimEnd(' ');




                for (int i = 0; i < login.Length; i++)
                {
                    if (login[i] != "")
                    {
                        this.login.Add(login[i]);
                        this.red.Add(Convert.ToDouble(red[i]));
                        this.green.Add(Convert.ToDouble(green[i]));
                        this.blue.Add(Convert.ToDouble(blue[i]));
                    }
                    else
                    {
                        this.login.Add(admin);
                        this.red.Add(white);
                        this.green.Add(white);
                        this.blue.Add(white);
                    }
                }
                fsLogin.Close();
                fsRed.Close();
                fsGreen.Close();
                fsBlue.Close();
            }
            catch (Exception)
            {
                FileStream fsLogin = new FileStream(pathLogin, FileMode.Create);
                FileStream fsRed = new FileStream(pathRed, FileMode.Create);
                FileStream fsGreen = new FileStream(pathGreen, FileMode.Create);
                FileStream fsBlue = new FileStream(pathBlue, FileMode.Create);
                
                this.login.Add("Admin");
                this.red.Add(white);
                this.green.Add(white);
                this.blue.Add(white);

                fsLogin.Position = 0;
                fsRed.Position = 0;
                fsGreen.Position = 0;
                fsBlue.Position = 0;

                fsLogin.Write(Encoding.ASCII.GetBytes("                          "), 0, 25);
                fsRed.Write(Encoding.ASCII.GetBytes("                          "), 0, 25);
                fsGreen.Write(Encoding.ASCII.GetBytes("                          "), 0, 25);
                fsBlue.Write(Encoding.ASCII.GetBytes("                          "), 0, 25);

                fsLogin.Position = 0;
                fsRed.Position = 0;
                fsGreen.Position = 0;
                fsBlue.Position = 0;

                fsLogin.Write(Encoding.ASCII.GetBytes(admin), 0, adminLenght);
                fsRed.Write(Encoding.ASCII.GetBytes(white.ToString()), 0, whiteLenght);
                fsGreen.Write(Encoding.ASCII.GetBytes(white.ToString()), 0, whiteLenght);
                fsBlue.Write(Encoding.ASCII.GetBytes(white.ToString()), 0, whiteLenght);

                fsLogin.Close();
                fsRed.Close();
                fsGreen.Close();
                fsBlue.Close();

                //____________________________________________________________

                FileStream fsLogins = new FileStream(pathLogin, FileMode.Open);
                FileStream fsReds = new FileStream(pathRed, FileMode.Open);
                FileStream fsGreens = new FileStream(pathGreen, FileMode.Open);
                FileStream fsBlues = new FileStream(pathBlue, FileMode.Open);

                byte[] bytesLogin = new byte[fsLogins.Length];
                byte[] bytesRed = new byte[fsLogins.Length];
                byte[] bytesGreen = new byte[fsLogins.Length];
                byte[] bytesBlue = new byte[fsLogins.Length];

                fsLogins.Read(bytesLogin, 0, bytesLogin.Length);
                fsReds.Read(bytesRed, 0, bytesRed.Length);
                fsGreens.Read(bytesGreen, 0, bytesGreen.Length);
                fsBlues.Read(bytesBlue, 0, bytesBlue.Length);

                dataLogin = Encoding.ASCII.GetString(bytesLogin);
                dataRed = Encoding.ASCII.GetString(bytesRed);
                dataGreen = Encoding.ASCII.GetString(bytesGreen);
                dataBlue = Encoding.ASCII.GetString(bytesBlue);

                this.login.Add(dataLogin);
                this.red.Add(Convert.ToDouble(dataRed));
                this.green.Add(Convert.ToDouble(dataGreen));
                this.blue.Add(Convert.ToDouble(dataBlue));

                fsLogins.Close();
                fsReds.Close();
                fsGreens.Close();
                fsBlues.Close();
            }
        }

        public bool CheckUser(string login, object error)
        {
            
            for (int i = 0; i < this.login.Count; i++)
            {
                if (login == this.login[i])
                {
                    return true;
                }
            }
            error = "Неправльный Логин!";
            return false;
        }

        public void SaveInFile()
        {
            File.AppendAllText(pathLogin, "");
            File.AppendAllText(pathRed, "");
            File.AppendAllText(pathGreen, "");
            File.AppendAllText(pathBlue, "");
            FileStream fsLogin = new FileStream(pathLogin, FileMode.Create);
            FileStream fsRed = new FileStream(pathRed, FileMode.Create);
            FileStream fsGreen = new FileStream(pathGreen, FileMode.Create);
            FileStream fsBlue = new FileStream(pathBlue, FileMode.Create);
            string login = "", red = "", green = "", blue = "";
            login= this.login[0];
            int size = this.login.Count;
            for (int i = 0; i < size; i++)
            {
                login += this.login[i] + ";";
                blue += this.blue[i].ToString() + ";";
                red += this.red[i].ToString() + ";";
                green += this.green[i].ToString() + ";";
            }


            fsLogin.Position = 0;
            fsRed.Position = 0;
            fsGreen.Position = 0;
            fsBlue.Position = 0;

            fsLogin.Write(Encoding.ASCII.GetBytes("                          "), 0, 25);
            fsRed.Write(Encoding.ASCII.GetBytes("                          "), 0, 25);
            fsGreen.Write(Encoding.ASCII.GetBytes("                          "), 0, 25);
            fsBlue.Write(Encoding.ASCII.GetBytes("                          "), 0, 25);

            fsLogin.Position = 0;
            fsRed.Position = 0;
            fsGreen.Position = 0;
            fsBlue.Position = 0;

            fsLogin.Write(Encoding.ASCII.GetBytes(login), 0, login.Length);
            fsRed.Write(Encoding.ASCII.GetBytes(red), 0, red.Length);
            fsGreen.Write(Encoding.ASCII.GetBytes(green), 0, green.Length);
            fsBlue.Write(Encoding.ASCII.GetBytes(blue), 0, blue.Length);

            fsLogin.Close();
            fsRed.Close();
            fsGreen.Close();
            fsBlue.Close();
        }
    }
}
