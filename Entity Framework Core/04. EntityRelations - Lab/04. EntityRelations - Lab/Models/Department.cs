using System;
using System.Collections.Generic;
using System.Text;

namespace _04._EntityRelations___Lab.Models
{
    public class Department
    {
        public Department()
        {
            this.Employees = new HashSet<Employee>(); 
        }
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }    
    }
}
