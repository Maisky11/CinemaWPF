using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWPF
{
    public class Hall
    {
        public int id { get; set; }
        public string name;
        public int rows, row_seats;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }
        public int Row_seats
        {
            get { return row_seats; }
            set { row_seats = value; }
        }
        public virtual ICollection<Place> Places { get; set; }
        public virtual ICollection<Session> Sessions  { get; set; }
        public Hall() 
        { 
            Places = new List<Place>();
            Sessions = new List<Session>();
        }
        public Hall(string name, int rows, int row_seats)
        {
            this.name = name;
            this.rows = rows;
            this.row_seats = row_seats;
        }
    }
}
