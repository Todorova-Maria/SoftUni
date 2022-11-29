using _03._EntityFramework_Introduction___Lab.Models;
using System;
class Program
{
    static void Main(string[] args)
    {
        var db = new SoftUniContext();
        Console.WriteLine(db.Employees.Count());
        Console.WriteLine(db.Addresses.Count());
    }
}