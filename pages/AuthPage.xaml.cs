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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        AppContext db;
        MainWindow window = Application.Current.MainWindow as MainWindow;
        public AuthPage()
        {
            InitializeComponent();
            db = new AppContext();
        }

        private void GoToRegPage_Click(object sender, RoutedEventArgs e)
        {
            window.MainFrame.Navigate(new Uri("/pages/RegPage.xaml", UriKind.Relative));
        }

        private void AuthButt_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = textBoxPassword.Password.Trim();

            User authUser = null;
            authUser = db.Users.Where(b => b.Login == login && b.Password == pass).FirstOrDefault();
            if (authUser != null)
            {
                window.userId = authUser.id;
                window.MainFrame.Navigate(new Uri("/pages/MainPage.xaml", UriKind.Relative));
            }
            else MessageBox.Show("Что-то введено не корректно");
        }
    }
}
