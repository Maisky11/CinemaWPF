using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWPF
{
    public class Movie
    {
        public int id { get; set; }
        public string title, genre;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public virtual ICollection<Session> Sessions { get; set; }
        public Movie() 
        {
            Sessions = new List<Session>();
        }
        public Movie(string title, string genre)
        {
            this.title = title;
            this.genre = genre;
        }
    }
}
