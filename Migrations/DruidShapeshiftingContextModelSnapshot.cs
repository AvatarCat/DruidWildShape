﻿// <auto-generated />
using System;
using DruidShapeshifting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DruidShapeshifting.Migrations
{
    [DbContext(typeof(DruidShapeshiftingContext))]
    partial class DruidShapeshiftingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("DruidShapeshifting.Models.Creature", b =>
                {
                    b.Property<int>("CreatureId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Armor");

                    b.Property<string>("Challenge")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.Property<int?>("DruidId");

                    b.Property<string>("HitPoints")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("CreatureId");

                    b.HasIndex("DruidId");

                    b.ToTable("Creature");
                });

            modelBuilder.Entity("DruidShapeshifting.Models.Druid", b =>
                {
                    b.Property<int>("DruidId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("DruidId");

                    b.ToTable("Druid");
                });

            modelBuilder.Entity("DruidShapeshifting.Models.Creature", b =>
                {
                    b.HasOne("DruidShapeshifting.Models.Druid", "Druid")
                        .WithMany("Creatures")
                        .HasForeignKey("DruidId");
                });
#pragma warning restore 612, 618
        }
    }
}
