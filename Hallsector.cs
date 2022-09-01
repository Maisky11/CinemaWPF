using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWPF
{
    public class Hallsector
    {
        public int id { get; set; }
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public virtual ICollection<Place> Places { get; set; }
        public Hallsector()
        {
            Places = new List<Place>();
        }
        public Hallsector(string name)
        {
            this.name = name;
        }
    }
}
