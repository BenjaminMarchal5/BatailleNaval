﻿// <auto-generated />
using System;
using BattleShip.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BattleShip.Model.Migrations
{
    [DbContext(typeof(BattleShipContext))]
    partial class BattleShipContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("BattleShip.Model.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GridSize")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WinnerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("BattleShip.Model.Model.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("BattleShip.Model.Model.RequiredShip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("NumberShip")
                        .HasColumnType("int");

                    b.Property<int>("SizeShip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("RequiredShip");
                });

            modelBuilder.Entity("BattleShip.Model.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("player_type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Players");

                    b.HasDiscriminator<string>("player_type").HasValue("Player");
                });

            modelBuilder.Entity("BattleShip.Model.Ship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("EndId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("StartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EndId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("StartId");

                    b.ToTable("Ships");
                });

            modelBuilder.Entity("BattleShip.Model.Shoot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("HasHit")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("HitId")
                        .HasColumnType("int");

                    b.Property<int>("IndexCoup")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("ShipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HitId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("ShipId");

                    b.ToTable("Shoots");
                });

            modelBuilder.Entity("BattleShip.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BattleShip.Model.Model.HumanPlayer", b =>
                {
                    b.HasBaseType("BattleShip.Model.Player");

                    b.Property<string>("NickName")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("player_human");
                });

            modelBuilder.Entity("BattleShip.Model.Model.IAPlayer", b =>
                {
                    b.HasBaseType("BattleShip.Model.Player");

                    b.Property<int>("EIALevel")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("player_IA");
                });

            modelBuilder.Entity("BattleShip.Model.Game", b =>
                {
                    b.HasOne("BattleShip.Model.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("BattleShip.Model.Model.RequiredShip", b =>
                {
                    b.HasOne("BattleShip.Model.Game", "Game")
                        .WithMany("RequiredShip")
                        .HasForeignKey("GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("BattleShip.Model.Player", b =>
                {
                    b.HasOne("BattleShip.Model.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("BattleShip.Model.Ship", b =>
                {
                    b.HasOne("BattleShip.Model.Model.Position", "End")
                        .WithMany()
                        .HasForeignKey("EndId");

                    b.HasOne("BattleShip.Model.Player", "Player")
                        .WithMany("Ships")
                        .HasForeignKey("PlayerId");

                    b.HasOne("BattleShip.Model.Model.Position", "Start")
                        .WithMany()
                        .HasForeignKey("StartId");

                    b.Navigation("End");

                    b.Navigation("Player");

                    b.Navigation("Start");
                });

            modelBuilder.Entity("BattleShip.Model.Shoot", b =>
                {
                    b.HasOne("BattleShip.Model.Model.Position", "Hit")
                        .WithMany()
                        .HasForeignKey("HitId");

                    b.HasOne("BattleShip.Model.Player", "Player")
                        .WithMany("Shoots")
                        .HasForeignKey("PlayerId");

                    b.HasOne("BattleShip.Model.Ship", "Ship")
                        .WithMany("Shoots")
                        .HasForeignKey("ShipId");

                    b.Navigation("Hit");

                    b.Navigation("Player");

                    b.Navigation("Ship");
                });

            modelBuilder.Entity("BattleShip.Model.Model.HumanPlayer", b =>
                {
                    b.HasOne("BattleShip.Model.User", "User")
                        .WithMany("Players")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BattleShip.Model.Game", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("RequiredShip");
                });

            modelBuilder.Entity("BattleShip.Model.Player", b =>
                {
                    b.Navigation("Ships");

                    b.Navigation("Shoots");
                });

            modelBuilder.Entity("BattleShip.Model.Ship", b =>
                {
                    b.Navigation("Shoots");
                });

            modelBuilder.Entity("BattleShip.Model.User", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
