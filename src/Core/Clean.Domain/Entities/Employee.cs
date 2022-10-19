﻿using Clean.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Domain.Entities
{
    public class Employee:AuditableEntity
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } 
        public string Job { get; set; }
                                
    }
}
