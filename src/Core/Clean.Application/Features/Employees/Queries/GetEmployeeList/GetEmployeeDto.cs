using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Features.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
    }
}
