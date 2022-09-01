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
    /// Логика взаимодействия для HallWindow.xaml
    /// </summary>
    public partial class HallWindow : Window
    {
        public Hall Hall { get; private set; }
        public HallWindow(Hall hall)
        {
            InitializeComponent();
            Hall = hall;
            DataContext = Hall;
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "" || textBoxRows.Text == "" || textBoxRow_seats.Text == "")
            {
                MessageBox.Show("Поле пустое", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if(!int.TryParse(textBoxRows.Text, out var number) || !int.TryParse(textBoxRow_seats.Text, out var number1))
            {
                MessageBox.Show("Неверный формат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
