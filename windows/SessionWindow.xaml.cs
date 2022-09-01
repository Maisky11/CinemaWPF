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
using System.Windows.Shapes;

namespace CinemaWPF.windows
{
    /// <summary>
    /// Логика взаимодействия для SessionWindow.xaml
    /// </summary>
    public partial class SessionWindow : Window
    {
        AppContext db;
        public Session Session { get; private set; }
        public SessionWindow(Session session)
        {
            InitializeComponent();
            db = new AppContext();
            Session = session;
            DataContext = Session;
            List<Hall> halls = db.Halls.ToList();
            comboBoxHall.ItemsSource = halls;
            comboBoxHall.DisplayMemberPath = "Name";
            comboBoxHall.SelectedValuePath = "id";
            List<Movie> movies = db.Movies.ToList();
            comboBoxMovie.ItemsSource = movies;
            comboBoxMovie.DisplayMemberPath = "Title";
            comboBoxMovie.SelectedValuePath = "id";
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxDate.Text == "" || textBoxTime.Text == "" || comboBoxMovie.SelectedItem == null || comboBoxHall.SelectedItem == null)
            {
                MessageBox.Show("Поле пустое", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DialogResult = true;
                this.Close();
            }
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
