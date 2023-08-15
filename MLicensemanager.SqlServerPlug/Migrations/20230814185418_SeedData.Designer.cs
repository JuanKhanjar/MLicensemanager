﻿// <auto-generated />
using MLicensemanager.SqlServerPlug.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MLicensemanager.SqlServerPlug.Migrations
{
    [DbContext(typeof(CLDbContext))]
    [Migration("20230814185418_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MLicensemanager.BusinessCore.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerID = 1,
                            Adress = "Agade 12",
                            Email = "a@gmail.com",
                            Title = "Aarhus Kommune"
                        },
                        new
                        {
                            CustomerID = 2,
                            Adress = "Vgade 12",
                            Email = "v@gmail.com",
                            Title = "Vejle Kommune"
                        });
                });

            modelBuilder.Entity("MLicensemanager.BusinessCore.CustomerGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.HasIndex("GroupID");

                    b.ToTable("CustomerGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerID = 1,
                            GroupID = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerID = 1,
                            GroupID = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerID = 2,
                            GroupID = 2
                        });
                });

            modelBuilder.Entity("MLicensemanager.BusinessCore.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupID"));

                    b.Property<string>("EAN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupID");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupID = 1,
                            EAN = "19781"
                        },
                        new
                        {
                            GroupID = 2,
                            EAN = "19782"
                        });
                });

            modelBuilder.Entity("MLicensemanager.BusinessCore.GroupProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupID");

                    b.HasIndex("ProductID");

                    b.ToTable("GroupProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GroupID = 1,
                            ProductID = 1
                        },
                        new
                        {
                            Id = 2,
                            GroupID = 1,
                            ProductID = 2
                        },
                        new
                        {
                            Id = 3,
                            GroupID = 2,
                            ProductID = 2
                        });
                });

            modelBuilder.Entity("MLicensemanager.BusinessCore.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            Name = "Miralix Desktop 330",
                            Price = 10.99m
                        },
                        new
                        {
                            ProductID = 2,
                            Name = "Miralix Go 12",
                            Price = 20.50m
                        });
                });

            modelBuilder.Entity("MLicensemanager.BusinessCore.CustomerGroup", b =>
                {
                    b.HasOne("MLicensemanager.BusinessCore.Customer", "Customer")
                        .WithMany("CustomerGroups")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MLicensemanager.BusinessCore.Group", "Group")
                        .WithMany("CustomerGroups")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("MLicensemanager.BusinessCore.GroupProduct", b =>
                {
                    b.HasOne("MLicensemanager.BusinessCore.Group", "Group")
                        .WithMany("GroupProducts")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MLicensemanager.BusinessCore.Product", "Product")
                        .WithMany("GroupProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MLicensemanager.BusinessCore.Customer", b =>
                {
                    b.Navigation("CustomerGroups");
                });

            modelBuilder.Entity("MLicensemanager.BusinessCore.Group", b =>
                {
                    b.Navigation("CustomerGroups");

                    b.Navigation("GroupProducts");
                });

            modelBuilder.Entity("MLicensemanager.BusinessCore.Product", b =>
                {
                    b.Navigation("GroupProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
