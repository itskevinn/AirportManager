﻿using Microsoft.EntityFrameworkCore;
using Security.Domain.Entity;

namespace Security.Infrastructure.Persistence.Seeding;

public static class Seeder
{
    public static void GenerateSeeds(ModelBuilder modelBuilder)
    {
        #region RoleSeed

        modelBuilder.Entity<Role>().HasData(
            new
            {
                Id = Guid.Parse("BF1DE1AA-FC78-4B92-6942-08DA36131198"), RoleName = "Admin", Status = true,
                CreatedBy = "AutoGenerated",
                CreatedOn = new DateTime(), LastModifiedBy = "AutoGenerated", LastModifiedOn = new DateTime()
            },
            new
            {
                Id = Guid.Parse("4A77CEE4-5CFA-4C90-B41A-08DA36159111"), RoleName = "User", Status = true,
                CreatedBy = "AutoGenerated",
                CreatedOn = new DateTime(), LastModifiedBy = "AutoGenerated", LastModifiedOn = new DateTime()
            }
        );

        #endregion

        #region UserSeed

        modelBuilder.Entity<User>().HasData(
            new
            {
                Id = Guid.Parse("4A77CEE4-5CFA-4C90-B41A-08DA36159120"), Name = "Kevin Pontón", Status = true,
                Username = "Admin", Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                CreatedBy = "AutoGenerated",
                Email = "kvnpntn@gmail.com",
                CreatedOn = new DateTime(), LastModifiedBy = "AutoGenerated", LastModifiedOn = new DateTime()
            },
            new
            {
                Id = Guid.Parse("C82A18C6-E473-4976-5F2E-08DA35E4EB6F"), Name = "Usuario", Status = true,
                Username = "User", Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                CreatedBy = "AutoGenerated",
                Email = "keviinpn2@gmail.com",
                CreatedOn = new DateTime(), LastModifiedBy = "AutoGenerated", LastModifiedOn = new DateTime()
            }
        );

        #endregion

        #region MenuItemSeed

        modelBuilder.Entity<MenuItem>().HasData(
            new
            {
                Id = Guid.Parse("504731d4-0a34-41d5-9b0b-0611b3f76096"), Icon = "fa-solid fa-plane-departure",
                Label = "Tickets",
                Order = 1,
                RouterLink = "tickets",
                CreatedBy = "AutoGenerated",
                Status = true,
                CreatedOn = DateTime.Now, LastModifiedBy = "AutoGenerated", LastModifiedOn = new DateTime()
            },
            new MenuItem
            {
                Id = Guid.Parse("504731d4-0a34-41d5-9b0b-0611b3f76098"), Icon = "fa-solid fa-plane-departure",
                Label = "Usuarios",
                CreatedOn = DateTime.Now,
                Order = 2,
                RouterLink = "users",
                CreatedBy = "AutoGenerated",
                Status = true,
                LastModifiedBy = "AutoGenerated", LastModifiedOn = new DateTime()
            }
        );

        #endregion

        #region UserRoleSeed

        modelBuilder.Entity<UserRole>().HasData(
            new
            {
                Id = Guid.Parse("BF1DE1AA-FC78-4B92-6942-09DA36131298"),
                UserId = Guid.Parse("4A77CEE4-5CFA-4C90-B41A-08DA36159120"),
                Status = true,
                RoleId = Guid.Parse("BF1DE1AA-FC78-4B92-6942-08DA36131198"),
                CreatedBy = "AutoGenerated",
                CreatedOn = new DateTime(),
                LastModifiedBy = "AutoGenerated", LastModifiedOn = new DateTime()
            },
            new
            {
                Id = Guid.Parse("BF1DE1AA-FC78-4B92-6942-09DA3E131298"),
                UserId = Guid.Parse("C82A18C6-E473-4976-5F2E-08DA35E4EB6F"),
                Status = true,
                RoleId = Guid.Parse("4A77CEE4-5CFA-4C90-B41A-08DA36159111"),
                CreatedBy = "AutoGenerated",
                CreatedOn = new DateTime(),
                LastModifiedBy = "AutoGenerated",
                LastModifiedOn = new DateTime()
            }
        );

        #endregion

        #region MenuItemRoleSeed

        modelBuilder.Entity<MenuItemRole>().HasData(
            new
            {
                Id = Guid.Parse("C82A18C6-E473-4976-5F2E-08DA35E4EBFE"),
                MenuItemId = Guid.Parse("504731d4-0a34-41d5-9b0b-0611b3f76096"),
                RoleId = Guid.Parse("BF1DE1AA-FC78-4B92-6942-08DA36131198"),
                Status = true,
                CreatedBy = "AutoGenerated",
                CreatedOn = new DateTime(),
                LastModifiedBy = "AutoGenerated",
                LastModifiedOn = new DateTime()
            },
            new
            {
                Id = Guid.Parse("C82A18C6-E473-4976-5F2E-08DA35E4EB8E"),
                MenuItemId = Guid.Parse("504731d4-0a34-41d5-9b0b-0611b3f76098"),
                RoleId = Guid.Parse("BF1DE1AA-FC78-4B92-6942-08DA36131198"),
                Status = true,
                CreatedBy = "AutoGenerated",
                CreatedOn = new DateTime(),
                LastModifiedBy = "AutoGenerated",
                LastModifiedOn = new DateTime()
            },
            new
            {
                Id = Guid.Parse("C82A18C6-E473-4976-5F2E-08DA35E4EB8B"),
                MenuItemId = Guid.Parse("504731d4-0a34-41d5-9b0b-0611b3f76098"),
                Status = true,
                RoleId = Guid.Parse("4A77CEE4-5CFA-4C90-B41A-08DA36159111"),
                CreatedBy = "AutoGenerated",
                CreatedOn = new DateTime(),
                LastModifiedBy = "AutoGenerated",
                LastModifiedOn = new DateTime()
            },
            new
            {
                Id = Guid.Parse("C82A18C6-E473-4976-5F2E-08DA35E4EB8A"),
                MenuItemId = Guid.Parse("504731d4-0a34-41d5-9b0b-0611b3f76096"),
                Status = true,
                RoleId = Guid.Parse("4A77CEE4-5CFA-4C90-B41A-08DA36159111"),
                CreatedBy = "AutoGenerated",
                CreatedOn = new DateTime(),
                LastModifiedBy = "AutoGenerated",
                LastModifiedOn = new DateTime()
            }
        );

        #endregion

    }
}