using _01.CodeFirstDemo.Models;
using System;

class Program
{
    static void Main(string[] args)
    {
        var db = new ApplicationDbContext(); 
        
        db.Database.EnsureCreated(); 
    }
}