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
            CreateAutoInclude(modelBuilder);
            modelBuilder.Entity<Ship>().Navigation(p => p.Start).AutoInclude();
            modelBuilder.Entity<Ship>().Navigation(p => p.End).AutoInclude();
        }

        private void CreateAutoInclude(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ship>().Navigation(p => p.Start).AutoInclude();
            modelBuilder.Entity<Ship>().Navigation(p => p.End).AutoInclude();
            modelBuilder.Entity<Ship>().Navigation(p => p.Shoots).AutoInclude();

            modelBuilder.Entity<Shoot>().Navigation(p => p.Hit).AutoInclude();

            modelBuilder.Entity<Player>().Navigation(p => p.Shoots).AutoInclude();
            modelBuilder.Entity<Player>().Navigation(p => p.Ships).AutoInclude();

            modelBuilder.Entity<Game>().Navigation(p => p.Players).AutoInclude();
            modelBuilder.Entity<Game>().Navigation(p => p.RequiredShip).AutoInclude();

            modelBuilder.Entity<User>().Navigation(p => p.Players).AutoInclude();
        }

        private void CreateRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(opt =>
            {
                opt.HasMany(x => x.Players).WithOne(x => x.Game).HasForeignKey(i=>i.GameId);
            });


            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasMany(x => x.Ships).WithOne(x => x.Player).HasForeignKey(i => i.PlayerId); ;
            });

            modelBuilder.Entity<Player>(opt =>
            {
                opt.HasMany(x => x.Shoots).WithOne(x => x.Player).HasForeignKey(i => i.PlayerId); ;
            });

            modelBuilder.Entity<Player>().HasDiscriminator<string>("player_type")
                .HasValue<HumanPlayer>("player_human")
                .HasValue<IAPlayer>("player_IA");


            modelBuilder.Entity<Ship>(opt =>
            {
                opt.HasMany(x => x.Shoots).WithOne(x => x.Ship).HasForeignKey(i => i.ShipId);
            });

            modelBuilder.Entity<User>(opt =>
            {
                opt.HasMany(x => x.Players).WithOne(x => x.User).HasForeignKey(i => i.UserId);
            });


            modelBuilder.Entity<Game>(opt =>
            {
                opt.HasMany(x => x.RequiredShip).WithOne(x => x.Game).HasForeignKey(i => i.GameId);
            });

        }

    }
}
