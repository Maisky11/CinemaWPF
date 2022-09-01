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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        MainWindow window = Application.Current.MainWindow as MainWindow;
        AppContext db;
        User mainUser;
        string pageName;
        public MainPage()
        {
            db = new AppContext();
            InitializeComponent();
            mainUser = db.Users.Where(b => b.id == window.userId).FirstOrDefault();
            textBlockLogin.Text = mainUser.Login;
            pageName = System.IO.Path.GetFileName(SecondFrame.Source.ToString());
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            window.userId = 0;
            window.MainFrame.Navigate(new Uri("/pages/AuthPage.xaml", UriKind.Relative));
        }

        private void NavHead_Button_Click(object sender, RoutedEventArgs e)
        {
            if(pageName != "HeadPage.xaml")
            {
                SecondFrame.Navigate(new Uri("/pages/HeadPage.xaml", UriKind.Relative));
                pageName = System.IO.Path.GetFileName(SecondFrame.Source.ToString());
            }
        }
        private void NavMovie_Button_Click(object sender, RoutedEventArgs e)
        {
            if (pageName != "MoviePage.xaml")
            {
                SecondFrame.Navigate(new Uri("/pages/MoviePage.xaml", UriKind.Relative));
                pageName = System.IO.Path.GetFileName(SecondFrame.Source.ToString());
            }
        }
        private void NavHall_Button_Click(object sender, RoutedEventArgs e)
        {
            if (pageName != "HallPage.xaml")
            {
                SecondFrame.Navigate(new Uri("/pages/HallPage.xaml", UriKind.Relative));
                pageName = System.IO.Path.GetFileName(SecondFrame.Source.ToString());
            }
        }

        private void NavSession_Button_Click(object sender, RoutedEventArgs e)
        {
            if (pageName != "SessionPage.xaml")
            {
                SecondFrame.Navigate(new Uri("/pages/SessionPage.xaml", UriKind.Relative));
                pageName = System.IO.Path.GetFileName(SecondFrame.Source.ToString());
            }
        }

        private void NavCab_Button_Click(object sender, RoutedEventArgs e)
        {
            if (pageName != "CabinetPage.xaml")
            {
                SecondFrame.Navigate(new Uri("/pages/CabinetPage.xaml", UriKind.Relative));
                pageName = System.IO.Path.GetFileName(SecondFrame.Source.ToString());
            }
        }
    }
}
