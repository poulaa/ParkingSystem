﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using parking_system.infrastructure;

namespace parking_system.Migrations
{
    [DbContext(typeof(db))]
    partial class dbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("parking_system.Models.car_owner", b =>
                {
                    b.Property<int>("car_owner_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("licen_number")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("car_owner_id");

                    b.ToTable("car_owner");
                });

            modelBuilder.Entity("parking_system.Models.park_slot", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("car_owner_id")
                        .HasColumnType("int");

                    b.Property<string>("day")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("licen_number")
                        .HasColumnType("int");

                    b.Property<string>("spot")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("id");

                    b.HasIndex("car_owner_id");

                    b.ToTable("park_slot");
                });

            modelBuilder.Entity("parking_system.Models.park_slot", b =>
                {
                    b.HasOne("parking_system.Models.car_owner", "car_owner")
                        .WithMany()
                        .HasForeignKey("car_owner_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}