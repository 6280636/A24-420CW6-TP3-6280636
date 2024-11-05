﻿// <auto-generated />
using System;
using A24_420CW6_TP3_6280636.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace A24_420CW6_TP3_6280636.Migrations
{
    [DbContext(typeof(A24_420CW6_TP3_6280636Context))]
    partial class A24_420CW6_TP3_6280636ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("A24_420CW6_TP3_6280636.Models.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Temp")
                        .HasColumnType("time");

                    b.Property<bool>("Visibilite")
                        .HasColumnType("bit");

                    b.Property<int>("scoreValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Score");
                });
#pragma warning restore 612, 618
        }
    }
}
