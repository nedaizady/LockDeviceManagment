using System;
using System.Collections.Generic;
using System.Text;

namespace Clay.AccessManagment.Domain.Entities
{
    public class Door: AuditableEntity
    {

        public int DoorId { get; set; }
        public string IdentityName { get; set; }
        public bool IsActive { get; set; }
        public List<EmployeeAccessRecord> EmployeeAccessRecords { get; set; }
        public virtual List<Employee> Employees { get; set; }
    }
}
