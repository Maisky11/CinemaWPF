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

namespace CinemaWPF.pages
{   
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        AppContext db;
        MainWindow window;
        public RegPage()
        {
            InitializeComponent();
            db = new AppContext();
            window = Application.Current.MainWindow as MainWindow;
        }

        private void GoToAuthPage_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new Uri("/pages/AuthPage.xaml", UriKind.Relative));
        }

        private void RegButt_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = textBoxPass.Password.Trim();
            string pass_2 = textBoxPass_2.Password.Trim();
            string email = textBoxEmail.Text.Trim();

            User regUser = null;
            regUser = db.Users.Where(b => b.Login == login).FirstOrDefault();
            if(regUser != null)
            {
                MessageBox.Show("Логин занят");
                return;
            }
            regUser = db.Users.Where(b => b.Email == email).FirstOrDefault();
            if(regUser != null)
            {
                MessageBox.Show("Такой email уже зарегистрирован");
                return;
            }
            if(pass != pass_2)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            MessageBox.Show("Успех");
            User user = new User(login, pass, email);
            db.Users.Add(user);
            db.SaveChanges();
            window.MainFrame.Navigate(new Uri("/pages/AuthPage.xaml", UriKind.Relative));
        }
    }
}
