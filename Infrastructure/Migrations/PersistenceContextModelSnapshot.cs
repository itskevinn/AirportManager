﻿// <auto-generated />
using System;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PersistenceContext))]
    partial class PersistenceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Airport")
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Airline", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("LastModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Airline", "Airport");
                });

            modelBuilder.Entity("Domain.Entities.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("LastModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("City", "Airport");
                });

            modelBuilder.Entity("Domain.Entities.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AirlineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CheckInTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CheckOutTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("DepartureCityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DestinyCityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FlightStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.HasIndex("AirlineId");

                    b.HasIndex("DepartureCityId");

                    b.HasIndex("DestinyCityId");

                    b.ToTable("Flight", "Airport");
                });

            modelBuilder.Entity("Domain.Entities.MenuItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("RouterLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("MenuItem", "Airport");

                    b.HasData(
                        new
                        {
                            Id = new Guid("012fff70-84e2-4962-84a3-3b7833bb71fb"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "fa-solid fa-house",
                            Label = "Inicio",
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Order = 0,
                            RouterLink = "home",
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        },
                        new
                        {
                            Id = new Guid("504731d4-0a34-41d5-9b0b-0611b3f76096"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "fa-solid fa-plane-departure",
                            Label = "Vuelos",
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Order = 1,
                            RouterLink = "flights",
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        },
                        new
                        {
                            Id = new Guid("0b63d953-fce2-4538-ba1d-0537680130ae"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "fa-solid fa-city",
                            Label = "Ciudades",
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Order = 3,
                            RouterLink = "cities",
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        },
                        new
                        {
                            Id = new Guid("a10dafa8-c540-4509-a08f-d8fe5ded1995"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Icon = "fa-solid fa-plane",
                            Label = "Aereolíneas",
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Order = 2,
                            RouterLink = "airlines",
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        });
                });

            modelBuilder.Entity("Domain.Entities.MenuItemRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MenuItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("RoleId", "MenuItemId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("MenuItemRole", "Airport");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"),
                            MenuItemId = new Guid("a10dafa8-c540-4509-a08f-d8fe5ded1995"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = new Guid("c82a18c6-e473-4976-5f2e-08da35e4eb1a"),
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        },
                        new
                        {
                            RoleId = new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"),
                            MenuItemId = new Guid("0b63d953-fce2-4538-ba1d-0537680130ae"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = new Guid("c82a18c6-e473-4976-5f2e-08da35e4ebef"),
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        },
                        new
                        {
                            RoleId = new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"),
                            MenuItemId = new Guid("504731d4-0a34-41d5-9b0b-0611b3f76096"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = new Guid("c82a18c6-e473-4976-5f2e-08da35e4ebfe"),
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        },
                        new
                        {
                            RoleId = new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"),
                            MenuItemId = new Guid("012fff70-84e2-4962-84a3-3b7833bb71fb"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = new Guid("c82a18c6-e473-4976-5f2e-08da35e4eb8e"),
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        },
                        new
                        {
                            RoleId = new Guid("4a77cee4-5cfa-4c90-b41a-08da36159111"),
                            MenuItemId = new Guid("012fff70-84e2-4962-84a3-3b7833bb71fb"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = new Guid("c82a18c6-e473-4976-5f2e-08da35e4eb8b"),
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        },
                        new
                        {
                            RoleId = new Guid("4a77cee4-5cfa-4c90-b41a-08da36159111"),
                            MenuItemId = new Guid("504731d4-0a34-41d5-9b0b-0611b3f76096"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = new Guid("c82a18c6-e473-4976-5f2e-08da35e4eb8a"),
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("LastModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("Id");

                    b.ToTable("Role", "Airport");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleName = "Admin",
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        },
                        new
                        {
                            Id = new Guid("4a77cee4-5cfa-4c90-b41a-08da36159111"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RoleName = "User",
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("LastModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("pazzword");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User", "Airport");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4a77cee4-5cfa-4c90-b41a-08da36159120"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Kevin Pontón",
                            Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                            Status = true,
                            UpdatedBy = "AutoGenerated",
                            Username = "Admin"
                        },
                        new
                        {
                            Id = new Guid("c82a18c6-e473-4976-5f2e-08da35e4eb6f"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Usuario",
                            Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            Status = true,
                            UpdatedBy = "AutoGenerated",
                            Username = "User"
                        });
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole", "Airport");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("bf1de1aa-fc78-4b92-6942-08da36131198"),
                            UserId = new Guid("4a77cee4-5cfa-4c90-b41a-08da36159120"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = new Guid("bf1de1aa-fc78-4b92-6942-09da36131298"),
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        },
                        new
                        {
                            RoleId = new Guid("4a77cee4-5cfa-4c90-b41a-08da36159111"),
                            UserId = new Guid("c82a18c6-e473-4976-5f2e-08da35e4eb6f"),
                            CreatedBy = "AutoGenerated",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id = new Guid("bf1de1aa-fc78-4b92-6942-09da3e131298"),
                            LastModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            UpdatedBy = "AutoGenerated"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Flight", b =>
                {
                    b.HasOne("Domain.Entities.Airline", "Airline")
                        .WithMany()
                        .HasForeignKey("AirlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.City", "DepartureCity")
                        .WithMany()
                        .HasForeignKey("DepartureCityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.City", "DestinyCity")
                        .WithMany()
                        .HasForeignKey("DestinyCityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Airline");

                    b.Navigation("DepartureCity");

                    b.Navigation("DestinyCity");
                });

            modelBuilder.Entity("Domain.Entities.MenuItemRole", b =>
                {
                    b.HasOne("Domain.Entities.MenuItem", "MenuItem")
                        .WithMany("MenuItemRoles")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("RoleMenuItems")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Entities.UserRole", b =>
                {
                    b.HasOne("Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.MenuItem", b =>
                {
                    b.Navigation("MenuItemRoles");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("RoleMenuItems");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
