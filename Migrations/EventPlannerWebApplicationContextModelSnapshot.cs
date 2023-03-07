﻿// <auto-generated />
using System;
using EventPlannerWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventPlannerWebApplication.Migrations
{
    [DbContext(typeof(EventPlannerWebApplicationContext))]
    partial class EventPlannerWebApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EventPlannerWebApplication.Models.Services.Drink", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("BauturaImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DenumireBautura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PretBautura")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("ID");

                    b.ToTable("Drink");
                });

            modelBuilder.Entity("EventPlannerWebApplication.Models.Services.Food", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumireMancare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MancareImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PretMancare")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("EventPlannerWebApplication.Models.Services.Locatie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CapacitateMaxima")
                        .HasColumnType("int");

                    b.Property<string>("DenumireLocatie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PretLocatie")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Locatie");
                });

            modelBuilder.Entity("EventPlannerWebApplication.Models.Services.Music", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DjImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeDj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PretDj")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Music");
                });

            modelBuilder.Entity("EventPlannerWebApplication.Models.Services.MyEvent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("LocatieID")
                        .HasColumnType("int");

                    b.Property<string>("Mentiune")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MusicID")
                        .HasColumnType("int");

                    b.Property<int?>("PhotographID")
                        .HasColumnType("int");

                    b.Property<int?>("TipEvenimentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LocatieID");

                    b.HasIndex("MusicID");

                    b.HasIndex("PhotographID");

                    b.HasIndex("TipEvenimentID");

                    b.ToTable("MyEvent");
                });

            modelBuilder.Entity("EventPlannerWebApplication.Models.Services.Photograph", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumirePhotograph")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotographImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PretPhotograph")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Photograph");
                });

            modelBuilder.Entity("EventPlannerWebApplication.Models.TipEveniment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DenumireEveniment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TipEveniment");
                });

            modelBuilder.Entity("EventPlannerWebApplication.Models.Services.MyEvent", b =>
                {
                    b.HasOne("EventPlannerWebApplication.Models.Services.Locatie", "Locatie")
                        .WithMany("MyEvents")
                        .HasForeignKey("LocatieID");

                    b.HasOne("EventPlannerWebApplication.Models.Services.Music", "Music")
                        .WithMany("MyEvents")
                        .HasForeignKey("MusicID");

                    b.HasOne("EventPlannerWebApplication.Models.Services.Photograph", "Photograph")
                        .WithMany("MyEvents")
                        .HasForeignKey("PhotographID");

                    b.HasOne("EventPlannerWebApplication.Models.TipEveniment", "TipEveniment")
                        .WithMany("MyEvents")
                        .HasForeignKey("TipEvenimentID");

                    b.Navigation("Locatie");

                    b.Navigation("Music");

                    b.Navigation("Photograph");

                    b.Navigation("TipEveniment");
                });

            modelBuilder.Entity("EventPlannerWebApplication.Models.Services.Locatie", b =>
                {
                    b.Navigation("MyEvents");
                });

            modelBuilder.Entity("EventPlannerWebApplication.Models.Services.Music", b =>
                {
                    b.Navigation("MyEvents");
                });

            modelBuilder.Entity("EventPlannerWebApplication.Models.Services.Photograph", b =>
                {
                    b.Navigation("MyEvents");
                });

            modelBuilder.Entity("EventPlannerWebApplication.Models.TipEveniment", b =>
                {
                    b.Navigation("MyEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
