using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CinemaWPF
{
    internal class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Hallsector> Hallsectors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public AppContext() : base("DefaultConnection") { }
    }
}
