﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RVezy.WebAPI.Infra.Data;

#nullable disable

namespace RVezy.WebAPI.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("RVezy.WebAPI.Domain.Entities.CalendarEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("ListingId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("RVezy.WebAPI.Domain.Entities.ListingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ListingUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PropertyType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("RVezy.WebAPI.Domain.Entities.ReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("ListingId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReviwerName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
