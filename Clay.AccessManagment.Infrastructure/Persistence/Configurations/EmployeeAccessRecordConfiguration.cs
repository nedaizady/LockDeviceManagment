using Clay.AccessManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clay.AccessManagment.Infrastructure.Persistence.Configurations
{
    public class EmployeeAccessRecordConfiguration  : IEntityTypeConfiguration<EmployeeAccessRecord>
    {
        public void Configure(EntityTypeBuilder<EmployeeAccessRecord> builder)
        {

            builder.HasKey(t => t.EmployeeAccessRecordId);
            builder.Property(t => t.EmployeeAccessRecordId).ValueGeneratedOnAdd();

            builder.Property(t => t.EmployeeId)
              .HasColumnType("int")
              .HasMaxLength(30);

            builder.Property(t => t.DoorId)
              .HasColumnType("int")
              .HasMaxLength(30);

            builder.Property(t => t.AccessStatus)
              .HasColumnType("bit");

            builder.HasOne(p => p.Employee)
              .WithMany(p => p.EmployeeAccessRecords)
              .HasForeignKey(p => p.EmployeeId);

            builder.HasOne(p => p.Door)
             .WithMany(p => p.EmployeeAccessRecords)
             .HasForeignKey(p => p.DoorId);

        }
    }
}
