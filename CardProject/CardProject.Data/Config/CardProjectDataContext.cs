using CardProject.Data.Entity.Card.Debit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProject.Data.Config
{
    public class CardProjectDataContext: DbContext
    {
        public DbSet<DebitCard> DebitCards { get; set; }

        public CardProjectDataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO: подключение к бд
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CardProject;Trusted_Connection=True;");
        }
    }
}
