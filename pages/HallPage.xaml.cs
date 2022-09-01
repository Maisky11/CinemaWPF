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
    /// Логика взаимодействия для HallPage.xaml
    /// </summary>
    public partial class HallPage : Page
    {
        AppContext db;
        public HallPage()
        {
            InitializeComponent();
            Refresh();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            HallWindow hallWindow = new HallWindow(new Hall());
            if (hallWindow.ShowDialog() == true)
            {
                Hall Hall = hallWindow.Hall;
                db.Halls.Add(Hall);
                db.SaveChanges();
                Refresh();
                List<Hallsector> hallsectors = db.Hallsectors.ToList();
                Hallsector Hallsector = db.Hallsectors.Where(b => b.Name == "Cиний").FirstOrDefault();
                if (Hallsector == null)
                {
                    Hallsector = new Hallsector("Cиний");
                    db.Hallsectors.Add(Hallsector);
                    db.SaveChanges();
                }
                for(int i = 1; i <= Hall.Rows; i++)
                {
                    for(int j = 1; j <= Hall.Row_seats; j++)
                    {
                        Place Place = new Place(i,j,Hall.id, Hallsector.id);
                        db.Places.Add(Place);
                        db.SaveChanges();
                    }
                }
                Refresh();
                listHall.Items.Refresh();
            }
        }
        private void Refresh()
        {
            db = new AppContext();
            List<Hall> halls = db.Halls.ToList();
            listHall.ItemsSource = halls;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(listHall.SelectedItem is Hall hall)) return;
            MessageBoxResult result;
            result = MessageBox.Show("Вы точно хотите удалить зал с названием " + hall.name, "Удаление", MessageBoxButton.YesNo, MessageBoxImage.None);
            if (result == MessageBoxResult.Yes)
            {
                db.Halls.Remove(hall);
                db.SaveChanges();
                Refresh();
                listHall.Items.Refresh();
            }
        }

        private void ChoiseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(listHall.SelectedItem is Hall hall)) return;
            MessageBoxResult result = MessageBox.Show("Вы точно хотите выбрать зал с названием " + hall.name, "Переход", MessageBoxButton.YesNo, MessageBoxImage.None);
            if (result == MessageBoxResult.Yes)
            {
                PlacePage placePage = new PlacePage(hall);
                NavigationService.Navigate(placePage);
            }
        }
    }
}
