using BattleShip.Model.Model;
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
        public DbSet<HumanPlayer> HumanPlayers { get; set; }
        public DbSet<IAPlayer> IAPlayers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateRelations(modelBuilder);
            //modelBuilder.Entity<Player>().Navigation(p => p.Ships).AutoInclude();
        }

        private void CreateRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(opt =>
            {
                opt.HasMany(x => x.Players).WithOne(x => x.Game);
            });


            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasMany(x => x.Ships).WithOne(x => x.Player);
            });

            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasMany(x => x.Shoots).WithOne(x => x.Player);
            });

            modelBuilder.Entity<Player>().HasDiscriminator<string>("player_type")
                .HasValue<HumanPlayer>("player_human")
                .HasValue<IAPlayer>("player_IA");


            modelBuilder.Entity<Ship>(opt =>
            {
                opt.HasMany(x => x.Shoots).WithOne(x => x.Ship);
            });

            modelBuilder.Entity<User>(opt =>
            {
                opt.HasMany(x => x.Players).WithOne(x => x.User);
            });


            modelBuilder.Entity<Game>(opt =>
            {
                opt.HasMany(x => x.RequiredShip).WithOne(x => x.Game);
            });

        }

    }
}
