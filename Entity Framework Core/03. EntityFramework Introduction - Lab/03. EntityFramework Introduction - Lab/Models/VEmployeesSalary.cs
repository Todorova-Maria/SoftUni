using System;
using System.Collections.Generic;

namespace _03._EntityFramework_Introduction___Lab.Models
{
    public partial class VEmployeesSalary
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public decimal Salary { get; set; }
    }
}
