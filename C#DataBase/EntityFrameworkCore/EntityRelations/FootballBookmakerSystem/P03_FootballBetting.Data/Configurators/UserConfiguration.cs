using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Configurators
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(c => c.Password)
                .IsUnicode(true);

            builder
                .Property(c => c.Username)
                .IsUnicode(true);

            builder
                .Property(c => c.Name)
                .IsUnicode(true);

            builder
                .Property(c => c.Email)
                .IsUnicode(true);
        }
    }
}
