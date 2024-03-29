﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ordering.Infrastructure.Persistence;

#nullable disable

namespace Ordering.Infrastructure.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20231106162802_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Ordering.Domain.Entities.Orders", b =>
                {
                    b.Property<int>("IDOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IDBook")
                        .HasColumnType("int");

                    b.Property<int>("IDDiscount")
                        .HasColumnType("int");

                    b.Property<string>("OrderName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IDOrder");

                    b.ToTable("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
