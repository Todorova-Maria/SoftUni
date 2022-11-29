using _02._ORM_Fundamentals___Lab;
using System;

class Program
{
    static void Main(string[] args)
    {
        var db = new SoftUniContext();

        var departments = db.Employees.GroupBy(x => x.Department.Name)
            .Select(x => new { Name = x.Key, Count = x.Count() })
            .ToList();

        foreach (var department in departments)
        {
            Console.WriteLine($"{department.Name} => {department.Count}");
        }

        

       // db.Towns.Add(new Town { Name = "Lovech" });
       // db.SaveChanges(); 
    }
    }