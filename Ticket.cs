using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWPF
{
    public class Ticket
    {
        public int id { get; set; }
        public decimal price;
        public int session_id { get; set; }
        public int place_id { get; set; }
        public int user_id { get; set; }
        public virtual User User { get; set; }
        public virtual Session Session { get; set; }
        public virtual Place Place { get; set; }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public Ticket() { }
        public Ticket(int session_id, int place_id, int user_id, decimal price)
        {
            this.session_id = session_id;
            this.place_id = place_id;
            this.user_id = user_id;
            this.price = price;
        }
    }
}
