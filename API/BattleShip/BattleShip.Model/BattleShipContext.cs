using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Model
{
    public class BattleShipContext : DbContext
    {
        public BattleShipContext(DbContextOptions<BattleShipContext> options) : base(options)
        {
        }
        public DbSet<Ship> Ships { get; set; }
        public DbSet<Shoot> Shoots { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string ch = "Server=localhost;Database=battleshipdb;Uid=root;Pwd=;";
            optionsBuilder.UseMySql(ch, ServerVersion.AutoDetect(ch));   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateRelations(modelBuilder);
        }

        private void CreateRelations(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Shoot>()
                   .HasKey(c => new { c.TacosId, c.IngredientId });
            */
        }

    }
}
