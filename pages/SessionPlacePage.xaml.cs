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
    /// Логика взаимодействия для SessionPlacePage.xaml
    /// </summary>
    public partial class SessionPlacePage : Page
    {
        AppContext db;
        MainWindow window = Application.Current.MainWindow as MainWindow;
        User mainUser;
        public Session Session { get; private set; }
        public SessionPlacePage(Session session)
        {
            InitializeComponent();
            db = new AppContext();
            Session = session;
            mainUser = db.Users.Where(b => b.id == window.userId).FirstOrDefault();
            string namePage = "Зал: " + Session.Hall.Name + " Фильм: " + Session.Movie.Title;
            textBlockMain.Text = namePage;
            Refresh();
        }
        private void Refresh()
        {
            placePanel.Children.Clear();
            db = new AppContext();
            List<Place> places = db.Places.Where(b => b.hall_id == Session.Hall.id).ToList();
            List<Ticket> tickets = db.Tickets.Where(b => b.session_id == Session.id).ToList();
            for (int i = 1; i <= Session.Hall.Rows; i++)
            {
                StackPanel rowPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 10, 0, 0),
                };
                placePanel.Children.Add(rowPanel);
                TextBlock rowBlock = new TextBlock
                {
                    Text = i.ToString(),
                    VerticalAlignment = VerticalAlignment.Center,
                    Foreground = Brushes.White,
                    Margin = new Thickness(0, 0, 10, 0),
                };
                rowPanel.Children.Add(rowBlock);
                for (int j = 1; j <= Session.Hall.Row_seats; j++)
                {
                    Place place = db.Places.Where(b => b.Row == i && b.Row_position == j).FirstOrDefault();
                    Button placeButton = new Button
                    {
                        Content = j.ToString(),
                        Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x7E, 0xFC)),
                        BorderBrush = new SolidColorBrush(Color.FromArgb(0xFF, 0x30, 0x7E, 0xFC)),
                        Style = (Style)FindResource("MaterialDesignIconButton"),
                        Foreground = Brushes.White,
                        Width = 35,
                        Height = 35,
                        Margin = new Thickness(0, 0, 10, 0),
                        Uid = place.id.ToString()

                    };
                    Ticket ticket = null;
                    ticket = db.Tickets.Where(b => b.session_id == Session.id && b.Place.Row == i && b.Place.Row_position == j).FirstOrDefault();
                    if(ticket != null)
                    {
                        placeButton.Background = Brushes.Red;
                        placeButton.BorderBrush = Brushes.Red;
                    }
                    else
                    {
                        placeButton.Click += BuyButton_Click;
                    }
                    rowPanel.Children.Add(placeButton);
                }
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Place place = db.Places.Find(Convert.ToInt32(((Button)e.OriginalSource).Uid));
            MessageBoxResult result = MessageBox.Show("Вы точно хотите купить " + place.row_position + " место в " + place.Row + " ряду", "Переход", MessageBoxButton.YesNo, MessageBoxImage.None);
            if (result == MessageBoxResult.Yes)
            {
                Ticket ticket = new Ticket(Session.id, place.id, mainUser.id, Convert.ToDecimal(200));
                db.Tickets.Add(ticket);
                db.SaveChanges();
                Refresh();
            } 
        }
    }
}
