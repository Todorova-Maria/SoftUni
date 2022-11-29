using _04._EntityRelations___Lab.Models;
using System;

namespace _04._EntityRelations___Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var department = new Department { DepartmentName = "HR" }; 

            for (int i = 0; i < 10; i++)
            {
                db.Employees.Add(new Employee
                {
                    FirstName = "Ivan_" + i ,
                    LastName = "Todorov",
                    StartWorkDate = new DateTime(2010 + i, 1, 1),
                    Salary = 100 + i,
                    Department = department, 

                });
            }
            db.SaveChanges();
        }
    }
}
