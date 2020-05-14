using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_Teams
{
    class SpelerContext : DbContext
    {
        public DbSet<Speler> Spelers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-VCI7746\SQLEXPRESS;Initial Catalog=EFTeamsOpdracht;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
