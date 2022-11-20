using System;
using System.Collections.Generic;
using System.Text;

namespace Clay.AccessManagment.Domain.Entities
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
