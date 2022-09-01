using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWPF
{
    public class Session
    {
        public int id { get; set; }
        public string session_date, start_time;
        public int hall_id { get; set; }
        public virtual Hall Hall { get; set; }
        public int movie_id { get; set; }
        public virtual Movie Movie { get; set; }
        public string Session_date
        {
            get { return session_date; }
            set { session_date = value; }
        }
        public string Start_time
        {
            get { return start_time; }
            set { start_time = value; }
        }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public Session() 
        { 
            Tickets = new List<Ticket>();
        }
        public Session(int hall_id, int movie_id, string session_date, string start_time)
        {
            this.hall_id = hall_id;
            this.movie_id = movie_id;
            this.session_date = session_date;
            this.start_time = start_time;
        }
    }
}
