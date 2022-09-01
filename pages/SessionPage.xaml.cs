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
using CinemaWPF.windows;

namespace CinemaWPF.pages
{
    /// <summary>
    /// Логика взаимодействия для SessionPage.xaml
    /// </summary>
    public partial class SessionPage : Page
    {
        AppContext db;
        public SessionPage()
        {
            InitializeComponent();
            Refresh();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            SessionWindow sessionWindow = new SessionWindow(new Session());
            if (sessionWindow.ShowDialog() == true)
            {
                Session Session = sessionWindow.Session;
                db.Sessions.Add(Session);
                db.SaveChanges();
                Refresh();
                listSession.Items.Refresh();
            }
        }
        private void Refresh()
        {
            db = new AppContext();
            List<Session> sessions = db.Sessions.ToList();
            listSession.ItemsSource = sessions;
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            // если ни одного объекта не выделено, выходим
            if (!(listSession.SelectedItem is Session session)) return;

            SessionWindow sessionWindow = new SessionWindow(new Session
            {
                id = session.id,
                movie_id = session.movie_id,
                hall_id = session.hall_id,
                Session_date = session.Session_date,
                Start_time = session.Start_time
            });

            if (sessionWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                session = db.Sessions.Find(sessionWindow.Session.id);
                if (session != null)
                {
                    session.movie_id = sessionWindow.Session.movie_id;
                    session.hall_id = sessionWindow.Session.hall_id;
                    session.Session_date = sessionWindow.Session.Session_date;
                    session.Start_time = sessionWindow.Session.Start_time;
                    db.SaveChanges();
                    Refresh();
                    listSession.Items.Refresh();
                }
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(listSession.SelectedItem is Session session)) return;
            MessageBoxResult result;
            result = MessageBox.Show("Вы точно хотите удалить сессию с фильмом " + session.Movie.Title + " в зале " + session.Hall.Name, "Удаление", MessageBoxButton.YesNo, MessageBoxImage.None);
            if (result == MessageBoxResult.Yes)
            {
                db.Sessions.Remove(session);
                db.SaveChanges();
                Refresh();
                listSession.Items.Refresh();
            }
        }

        private void ChoiseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(listSession.SelectedItem is Session session)) return;
            MessageBoxResult result;
            result = MessageBox.Show("Вы точно хотите выбрать сессию с фильмом " + session.Movie.Title + " в зале " + session.Hall.Name, "Переход", MessageBoxButton.YesNo, MessageBoxImage.None);
            if (result == MessageBoxResult.Yes)
            {
                SessionPlacePage sessionPlacePage = new SessionPlacePage(session);
                NavigationService.Navigate(sessionPlacePage);
            }
        }
    }
}

