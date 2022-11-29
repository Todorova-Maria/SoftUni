using _01._StudentSystem.Models;
using System;
using System.Globalization;
using System.Linq;


public class Program
{
    public static void Main(string[] args)

    {
        var context = new StudentSystemContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated(); 
    }
}