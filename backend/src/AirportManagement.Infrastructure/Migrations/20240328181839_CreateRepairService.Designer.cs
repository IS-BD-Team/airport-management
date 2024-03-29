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
    [Migration("20240328181839_CreateRepairService")]
    partial class CreateRepairService
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("AirportManagement.Domain.Airplane.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Classification")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("CrewMembers")
                        .HasColumnType("int");

                    b.Property<bool>("HasReceivedMaintenance")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MaxLoad")
                        .HasColumnType("int");

                    b.Property<int>("PassengersCapacity")
                        .HasColumnType("int");

                    b.Property<string>("PlanePlate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("Id");

                    b.ToTable("Airplanes");
                });

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

            modelBuilder.Entity("AirportManagement.Domain.Clients.ClientRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("PlaneStayId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PlaneStayId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ClientRatings");
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

            modelBuilder.Entity("AirportManagement.Domain.Facility.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AirportId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AirportId");

                    b.HasIndex("Id");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("AirportManagement.Domain.PlaneStay.PlaneStay", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AirplaneId")
                        .HasColumnType("int");

                    b.Property<int>("AirportId")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CreationDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DepartureDate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("AirportId");

                    b.ToTable("PlaneStays");
                });

            modelBuilder.Entity("AirportManagement.Domain.Services.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AirplaneId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneId");

                    b.HasIndex("FacilityId");

                    b.HasIndex("Id");

                    b.ToTable("Services");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Service");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AirportManagement.Domain.Services.RepairService", b =>
                {
                    b.HasBaseType("AirportManagement.Domain.Services.Service");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("RepairService");
                });

            modelBuilder.Entity("AirportManagement.Domain.Airplane.Airplane", b =>
                {
                    b.HasOne("AirportManagement.Domain.Clients.Client", "Owner")
                        .WithMany("Airplanes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("AirportManagement.Domain.Clients.ClientRating", b =>
                {
                    b.HasOne("AirportManagement.Domain.Clients.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportManagement.Domain.PlaneStay.PlaneStay", null)
                        .WithMany("Ratings")
                        .HasForeignKey("PlaneStayId");

                    b.HasOne("AirportManagement.Domain.Services.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("AirportManagement.Domain.Facility.Facility", b =>
                {
                    b.HasOne("AirportManagement.Domain.Airports.Airport", "Airport")
                        .WithMany("Facilities")
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airport");
                });

            modelBuilder.Entity("AirportManagement.Domain.PlaneStay.PlaneStay", b =>
                {
                    b.HasOne("AirportManagement.Domain.Airplane.Airplane", "Airplane")
                        .WithMany()
                        .HasForeignKey("AirplaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirportManagement.Domain.Airports.Airport", "Airport")
                        .WithMany()
                        .HasForeignKey("AirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airplane");

                    b.Navigation("Airport");
                });

            modelBuilder.Entity("AirportManagement.Domain.Services.Service", b =>
                {
                    b.HasOne("AirportManagement.Domain.Airplane.Airplane", null)
                        .WithMany("Services")
                        .HasForeignKey("AirplaneId");

                    b.HasOne("AirportManagement.Domain.Facility.Facility", "Facility")
                        .WithMany("Services")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("AirportManagement.Domain.Airplane.Airplane", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("AirportManagement.Domain.Airports.Airport", b =>
                {
                    b.Navigation("Facilities");
                });

            modelBuilder.Entity("AirportManagement.Domain.Clients.Client", b =>
                {
                    b.Navigation("Airplanes");
                });

            modelBuilder.Entity("AirportManagement.Domain.Facility.Facility", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("AirportManagement.Domain.PlaneStay.PlaneStay", b =>
                {
                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
