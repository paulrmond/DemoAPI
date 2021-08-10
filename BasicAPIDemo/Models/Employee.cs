using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAPIDemo.Models
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    }
}
