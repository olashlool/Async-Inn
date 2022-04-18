﻿// <auto-generated />
using Async_Inn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Async_Inn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    partial class AsyncInnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Async_Inn.Models.Amenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "coffee maker"
                        },
                        new
                        {
                            ID = 2,
                            Name = "ocean view"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Mini bar"
                        });
                });

            modelBuilder.Entity("Async_Inn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Amman",
                            Country = "Jordan",
                            Name = "Mövenpick Hotel Amman",
                            Phone = "(06) 552 8822",
                            State = "Madina Monawarah",
                            StreetAddress = "Madina Monawarah Street, Al-Jathimiya St."
                        },
                        new
                        {
                            ID = 2,
                            City = "Amman",
                            Country = "Jordan",
                            Name = "Opal Hotel",
                            Phone = "(06) 412 0021",
                            State = "Airport Rd",
                            StreetAddress = "Airport Rd., Amman 11123"
                        },
                        new
                        {
                            ID = 3,
                            City = "Dead Sea",
                            Country = "Jordan",
                            Name = "Movenpick Resort",
                            Phone = "(05) 356 1111",
                            State = "Dead Sea Road",
                            StreetAddress = "Dead Sea Road, Sweimah 11180 Jordan"
                        });
                });

            modelBuilder.Entity("Async_Inn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 0,
                            Name = "Studio"
                        },
                        new
                        {
                            ID = 2,
                            Layout = 1,
                            Name = "One Bedroom"
                        },
                        new
                        {
                            ID = 3,
                            Layout = 2,
                            Name = "Two Bedroom"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
