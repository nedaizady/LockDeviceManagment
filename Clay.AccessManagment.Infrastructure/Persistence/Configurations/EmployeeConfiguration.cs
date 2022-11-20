using Clay.AccessManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clay.AccessManagment.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.HasQueryFilter(item => item.IsActive == true);
            builder.HasKey(t => t.EmployeeId);
            builder.Property(t => t.EmployeeId).ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
              .HasColumnType("varchar")
              .HasMaxLength(30)
              .IsRequired();

            builder.Property(t => t.FamilyName)
              .HasColumnType("varchar")
              .HasMaxLength(30)
              .IsRequired();

            builder.Property(t => t.UserName).HasColumnType("varchar").HasMaxLength(30).IsRequired();

            builder.Property(t => t.Password).HasColumnType("varchar").HasMaxLength(30).IsRequired();

            builder.Property(t => t.HasReportingAccess)
              .HasColumnType("bit")
              .HasDefaultValue(false);

            builder.Property(t => t.IsActive)
              .HasColumnType("bit")
              .HasDefaultValue(true);


        }
    }
}
