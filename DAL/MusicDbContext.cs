using OurModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MusicDbContext:DbContext
    {
        private static readonly string _connectionString = "MusicDb";

        public MusicDbContext() : base(_connectionString){}

        public DbSet<Studio> Studios { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
    }
}
