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
    /// Логика взаимодействия для MoviePage.xaml
    /// </summary>
    public partial class MoviePage : Page
    {
        AppContext db;
        public MoviePage()
        {
            InitializeComponent();
            Refresh();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MovieWindow movieWindow = new MovieWindow(new Movie());
            if (movieWindow.ShowDialog() == true)
            {
                Movie Movie = movieWindow.Movie;
                db.Movies.Add(Movie);
                db.SaveChanges();
                Refresh();
                listMovie.Items.Refresh();
            }
        }
        private void Refresh()
        {
            db = new AppContext();
            List<Movie> movies = db.Movies.ToList();
            listMovie.ItemsSource = movies;
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // получаем выделенный объект
            // если ни одного объекта не выделено, выходим
            if (!(listMovie.SelectedItem is Movie movie)) return;

            MovieWindow movieWindow = new MovieWindow(new Movie
            {
                id = movie.id,
                Title = movie.Title,
                Genre = movie.Genre
            });

            if (movieWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                movie = db.Movies.Find(movieWindow.Movie.id);
                if (movie != null)
                {
                    movie.Title = movieWindow.Movie.Title;
                    movie.Genre = movieWindow.Movie.Genre;
                    db.SaveChanges();
                    Refresh();
                    listMovie.Items.Refresh();
                }
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(listMovie.SelectedItem is Movie movie)) return;
            MessageBoxResult result;
            result = MessageBox.Show("Вы точно хотите удалить фильм с названием " + movie.title, "Удаление", MessageBoxButton.YesNo, MessageBoxImage.None);
            if(result == MessageBoxResult.Yes)
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
                Refresh();
                listMovie.Items.Refresh();
            }
        }
    }
}
