﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StoredProc.Data;

namespace StoredProc.Migrations
{
    [DbContext(typeof(StoredProcDbContext))]
    [Migration("20211123122034_cari")]
    partial class cari
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoredProc.Models.Employee", b =>
                {
                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("FirstName");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("StoredProcedure.Models.Car", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("carColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("carManufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("carModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("carModelYear")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
