using Clay.AccessManagment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clay.AccessManagment.Domain.Entities
{
    public class EmployeeAccessRecord
    {
        public long EmployeeAccessRecordId { get; set; }
        public int EmployeeId { get; set; }
        public int DoorId { get; set; }
        public bool AccessStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public AccessToolType AccessTool { get; set; }
        public Employee Employee { get; set; }
        public Door Door { get; set; }


    }
}
