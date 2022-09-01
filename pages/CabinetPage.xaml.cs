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
    /// Логика взаимодействия для CabinetPage.xaml
    /// </summary>
    public partial class CabinetPage : Page
    {
        AppContext db;
        MainWindow window = Application.Current.MainWindow as MainWindow;
        User mainUser;
        public CabinetPage()
        {
            InitializeComponent();
            db = new AppContext();
            mainUser = db.Users.Find(window.userId);
            Refresh();
        }
        private void Refresh()
        {
            db = new AppContext();
            List<Ticket> tickets = db.Tickets.Where(b => b.user_id == mainUser.id).ToList();
            listTicket.ItemsSource = tickets;
        }

    }
}
