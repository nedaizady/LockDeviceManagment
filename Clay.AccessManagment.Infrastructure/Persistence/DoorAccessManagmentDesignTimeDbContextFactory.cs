using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clay.AccessManagment.Infrastructure.Persistence
{
    public class DoorAccessManagmentDesignTimeDbContextFactory: IDesignTimeDbContextFactory<DoorAccessManagmentDbContext>
    {
        public DoorAccessManagmentDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DoorAccessManagmentDbContext>()
                .UseSqlServer(
                    "Integrated Security=SSPI;Persist Security Info=False; TrustServerCertificate=true; Initial Catalog=DoorAccessManagment;Data Source=DESKTOP-FP437TP");

            return new DoorAccessManagmentDbContext(optionsBuilder.Options);
        }
    }
}
