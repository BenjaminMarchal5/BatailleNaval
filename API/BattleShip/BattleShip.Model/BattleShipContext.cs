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
        public BattleShipContext()
        {
        }

        public BattleShipContext(DbContextOptions<BattleShipContext> options) : base(options)
        {
        }
        public DbSet<Ship> Ship { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateRelations(modelBuilder);
        }

        private void CreateRelations(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Composition>()
                   .HasKey(c => new { c.TacosId, c.IngredientId });
            */
        }

    }
}
