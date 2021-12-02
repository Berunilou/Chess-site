using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataSource : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Anonym> Anonymous { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Move> Moves { get; set; }

        public DataSource()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\;Database=Chess;Integrated Security=True;");
        }
    }
}
