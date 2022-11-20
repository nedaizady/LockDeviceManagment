using Clay.AccessManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Clay.AccessManagment.Infrastructure.Persistence.Configurations
{
    public class DoorConfiguration : IEntityTypeConfiguration<Door>
    {
        public void Configure(EntityTypeBuilder<Door> builder)
        {
            //builder.HasQueryFilter(item => item.IsActive == true);
            builder.HasKey(t => t.DoorId);
            builder.Property(t => t.DoorId).ValueGeneratedOnAdd();

            builder.Property(t => t.IdentityName).HasColumnType("varchar").HasMaxLength(30).IsRequired();


            builder.Property(t => t.IsActive)
           .HasColumnType("bit")
           .HasDefaultValue(true);


        }
    }
}
