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
    /// Логика взаимодействия для PlacePage.xaml
    /// </summary>
    public partial class PlacePage : Page
    {
        AppContext db;
        public Hall Hall { get; private set; }
        public PlacePage(Hall hall)
        {
            InitializeComponent();
            Hall = hall;
            textBlockMain.Text = Hall.Name;
            Refresh();
        }
        private void Refresh()
        {
            db = new AppContext();
            List<Place> places = db.Places.Where(b => b.hall_id == Hall.id).ToList();
            for(int i = 1; i <= Hall.Rows; i++)
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
                for (int j = 1; j <= Hall.Row_seats; j++)
                {
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
                        Uid = db.Places.Where(b => b.Row == i || b.Row_position == j).FirstOrDefault().id.ToString()
                    };
                    rowPanel.Children.Add(placeButton);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
