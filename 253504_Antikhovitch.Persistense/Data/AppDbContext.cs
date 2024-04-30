using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _253504_Antikhovitch.Persistense.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<Participant> Participants { get; set; } // DbSet для сущности Participant

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated(); // Создание базы данных
        }

        // Метод, вызываемый при инициализации контекста
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Определение структуры базы данных

            modelBuilder.Entity<Participant>()
                .OwnsOne(t => t.PersonalData);
        }
    }
}
