using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWPF
{
    public class Place
    {
        public int id { get; set; }
        public int row, row_position;
        public int hall_id { get; set; }
        public virtual Hall Hall { get; set; }
        public int hallsector_id { get; set; }
        public virtual Hallsector Hallsector { get; set; }
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public int Row_position
        {
            get { return row_position; }
            set { row_position = value; }
        }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public Place() 
        { 
            Tickets = new List<Ticket>();
        }
        public Place(int row, int row_position, int hall_id, int hallsector_id)
        {
            this.row = row;
            this.row_position = row_position;
            this.hall_id = hall_id;
            this.hallsector_id = hallsector_id;
        }
    }
}
