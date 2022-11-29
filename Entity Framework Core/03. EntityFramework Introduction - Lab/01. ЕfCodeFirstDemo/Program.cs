using _01._ЕfCodeFirstDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
class Program
{
    static void Main(string[] args)
    {
        var db = new SlidoDbContext();
        db.Database.Migrate();

    }
}