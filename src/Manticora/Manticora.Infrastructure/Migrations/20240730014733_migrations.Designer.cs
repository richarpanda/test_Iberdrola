﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Manticora.Infrastructure.Migrations
{
    [DbContext(typeof(ManticoraDbContext))]
    [Migration("20240730014733_migrations")]
    partial class migrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("Manticora.Domain.Entities.Db.Attack", b =>
                {
                    b.Property<int>("AttackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityDamage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DefenderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Distance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ManticoraDamage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Round")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WeaponId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AttackId");

                    b.HasIndex("DefenderId");

                    b.HasIndex("GameId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Attacks");
                });

            modelBuilder.Entity("Manticora.Domain.Entities.Db.Defender", b =>
                {
                    b.Property<int>("DefenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CharacterId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gold")
                        .HasColumnType("INTEGER");

                    b.HasKey("DefenderId");

                    b.ToTable("Defenders");
                });

            modelBuilder.Entity("Manticora.Domain.Entities.Db.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AttackingNation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CityHealth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ManticoraHealth")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Manticora.Domain.Entities.Db.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DefenderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WeaponId")
                        .HasColumnType("INTEGER");

                    b.HasKey("InventoryId");

                    b.HasIndex("DefenderId");

                    b.HasIndex("WeaponId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Manticora.Domain.Entities.Db.Weapon", b =>
                {
                    b.Property<int>("WeaponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Range")
                        .HasColumnType("INTEGER");

                    b.HasKey("WeaponId");

                    b.ToTable("Weapons");

                    b.HasData(
                        new
                        {
                            WeaponId = 1,
                            Cost = 80,
                            Name = "Gran cañón",
                            Range = 50
                        },
                        new
                        {
                            WeaponId = 2,
                            Cost = 60,
                            Name = "Metralla",
                            Range = 40
                        },
                        new
                        {
                            WeaponId = 3,
                            Cost = 50,
                            Name = "Mosquete",
                            Range = 30
                        },
                        new
                        {
                            WeaponId = 4,
                            Cost = 30,
                            Name = "Pistola",
                            Range = 20
                        },
                        new
                        {
                            WeaponId = 5,
                            Cost = 10,
                            Name = "Granada",
                            Range = 10
                        });
                });

            modelBuilder.Entity("Manticora.Domain.Entities.Db.Attack", b =>
                {
                    b.HasOne("Manticora.Domain.Entities.Db.Defender", "Defender")
                        .WithMany()
                        .HasForeignKey("DefenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manticora.Domain.Entities.Db.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manticora.Domain.Entities.Db.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Defender");

                    b.Navigation("Game");

                    b.Navigation("Weapon");
                });

            modelBuilder.Entity("Manticora.Domain.Entities.Db.Inventory", b =>
                {
                    b.HasOne("Manticora.Domain.Entities.Db.Defender", "Defender")
                        .WithMany()
                        .HasForeignKey("DefenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manticora.Domain.Entities.Db.Weapon", "Weapon")
                        .WithMany()
                        .HasForeignKey("WeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Defender");

                    b.Navigation("Weapon");
                });
#pragma warning restore 612, 618
        }
    }
}
