﻿// <auto-generated />
using System;
using BicycleRent.Domain.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BicycleRent.Domain.Migrations
{
    [DbContext(typeof(BicycleRentContext))]
    [Migration("20241123152951_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("BicycleRent.Domain.Bicycle", b =>
                {
                    b.Property<string>("SerialNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("SerialNumber");

                    b.HasIndex("TypeId");

                    b.ToTable("Bicycles");
                });

            modelBuilder.Entity("BicycleRent.Domain.BicycleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("RentalPrice")
                        .HasColumnType("double");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BicycleTypes");
                });

            modelBuilder.Entity("BicycleRent.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BicycleRent.Domain.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Begin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("BicycleSerialNumber")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("BicycleSerialNumber");

                    b.HasIndex("CustomerId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("BicycleRent.Domain.Bicycle", b =>
                {
                    b.HasOne("BicycleRent.Domain.BicycleType", "BicycleType")
                        .WithMany("Bicycles")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BicycleType");
                });

            modelBuilder.Entity("BicycleRent.Domain.Rental", b =>
                {
                    b.HasOne("BicycleRent.Domain.Bicycle", "Bicycle")
                        .WithMany("Rentals")
                        .HasForeignKey("BicycleSerialNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BicycleRent.Domain.Customer", "Customer")
                        .WithMany("Rentals")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Bicycle");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BicycleRent.Domain.Bicycle", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("BicycleRent.Domain.BicycleType", b =>
                {
                    b.Navigation("Bicycles");
                });

            modelBuilder.Entity("BicycleRent.Domain.Customer", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}