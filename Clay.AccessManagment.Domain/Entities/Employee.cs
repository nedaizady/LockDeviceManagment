using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clay.AccessManagment.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        private string _FullName;


        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        [NotMapped]
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = Name + "" + FamilyName; }
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool HasReportingAccess { get; set; }
        public bool IsActive { get; set; }
        public List<EmployeeAccessRecord> EmployeeAccessRecords { get; set; }
        public List<Door> Doors { get; set; }
    }
}
