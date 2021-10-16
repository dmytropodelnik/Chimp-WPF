﻿using First_App.Models.DataBase.Models;
using FirstApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace First_App.Models.DataBase.Configurations
{
    /// <summary>
    ///     Class of user profile configuration.
    /// </summary>
    public class UserProfilesConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.Property(u => u.MaxScore).HasDefaultValue(0);
            builder.Property(u => u.AverageScore).HasDefaultValue(0);
            builder.Property(u => u.GameCount).HasDefaultValue(0);

            builder.HasData(
              new UserProfile[]
              {
                  new UserProfile { Id = 1, UserId = 1, GameCount = 0 },
                  new UserProfile { Id = 2, UserId = 2 },
              });
        }
    }
}
