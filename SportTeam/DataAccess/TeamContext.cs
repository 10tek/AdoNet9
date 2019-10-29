using Microsoft.EntityFrameworkCore;
using SportTeam.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportTeam.DataAccess
{
    public class TeamContext : DbContext
    {
        private readonly string connectionString;

        public TeamContext(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            var warriors = new Team { Name = "Golden State Warriors" };
            var leakers = new Team { Name = "LA Leakers" };
            var barcelona = new Team { Name = "Barcelona" };

            builder.Entity<Team>().HasData(warriors);
            builder.Entity<Team>().HasData(leakers);
            builder.Entity<Team>().HasData(barcelona);

            builder.Entity<Player>().HasData(new Player { FullName = "Стефен Карри", TeamId = warriors.Id });
            builder.Entity<Player>().HasData(new Player { FullName = "Дрэймонд Грин", TeamId = warriors.Id });
            builder.Entity<Player>().HasData(new Player { FullName = "Клей Томпсон", TeamId = warriors.Id });

            builder.Entity<Player>().HasData(new Player { FullName = "Леброн Джеймс", TeamId = leakers.Id });
            builder.Entity<Player>().HasData(new Player { FullName = "Зак Норвелл", TeamId = leakers.Id });
            builder.Entity<Player>().HasData(new Player { FullName = "Трой Дэниэлс", TeamId = leakers.Id });

            builder.Entity<Player>().HasData(new Player { FullName = "Лионель Месси", TeamId = barcelona.Id });
            builder.Entity<Player>().HasData(new Player { FullName = "Антуан Гризман", TeamId = barcelona.Id });
            builder.Entity<Player>().HasData(new Player { FullName = "Луис Суарес", TeamId = barcelona.Id });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);
        }
    }
}
