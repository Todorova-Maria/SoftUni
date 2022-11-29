using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _02._ORM_Fundamentals___Lab
{
    public partial class Employee
    {
        public Employee()
        {
            Departments = new HashSet<Department>();
            InverseManager = new HashSet<Employee>();
            Projects = new HashSet<Project>();
        }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string JobTitle { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public int ManagerId { get; set; }
        public DateTime HireDate { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<Employee> InverseManager { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
