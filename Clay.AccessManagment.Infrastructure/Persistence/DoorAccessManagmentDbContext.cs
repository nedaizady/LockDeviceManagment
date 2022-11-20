using Clay.AccessManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clay.AccessManagment.Infrastructure.Persistence
{

    public class DoorAccessManagmentDbContext : DbContext
    {
        public DoorAccessManagmentDbContext()
        {
        }

        public DoorAccessManagmentDbContext(DbContextOptions<DoorAccessManagmentDbContext> options) : base(options)
        {
        }


        public DbSet<Door> Doors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAccessRecord> EmployeeAccessRecords { get; set; }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            foreach (var auditableEntityEntry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (auditableEntityEntry.State)
                {
                    case EntityState.Added:
                        auditableEntityEntry.Entity.CreatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        auditableEntityEntry.Entity.ModifiedAt = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Employee>()
            .HasMany(s => s.Doors)
            .WithMany(c => c.Employees)
            //.Map(f =>
            //{
            //    f.MapLeftKey("EmployeeRefId");
            //    f.MapRightKey("DoorRefId");
            //    f.ToTable("EmployeeDoor");
            //})
            ;


            base.OnModelCreating(modelBuilder);
        }
    }

}
