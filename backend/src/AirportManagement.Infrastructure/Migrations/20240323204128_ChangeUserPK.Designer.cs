﻿// <auto-generated />
using System;
using AirportManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirportManagement.Infrastructure.Migrations
{
    [DbContext(typeof(AirportManagementDbContext))]
    [Migration("20240323204128_ChangeUserPK")]
    partial class ChangeUserPK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AirportManagement.Domain.Airports.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GeographicLocation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("AirportManagement.Domain.Clients.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArrivalRole")
                        .HasColumnType("int");

                    b.Property<string>("Ci")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ClientType")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AirportManagement.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsSuperAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AirportManagement.Domain.Planes.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("ArriveDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DepartureDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MaxLoad")
                        .HasColumnType("int");

                    b.Property<int>("PassengersCapacity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Plane");
                });

            modelBuilder.Entity("AirportManagement.Domain.Planes.Plane", b =>
                {
                    b.HasOne("AirportManagement.Domain.Clients.Client", null)
                        .WithMany("Planes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AirportManagement.Domain.Clients.Client", b =>
                {
                    b.Navigation("Planes");
                });
#pragma warning restore 612, 618
        }
    }
}