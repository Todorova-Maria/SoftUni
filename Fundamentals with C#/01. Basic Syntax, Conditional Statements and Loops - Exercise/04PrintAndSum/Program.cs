using System;

public class Program
{
    public static void Main(string[] args)
    {
        var start = int.Parse(Console.ReadLine());   
        var end = int.Parse(Console.ReadLine());

        var TotalSum = 0;

        for (int i = start; i <= end; i++)
        {
            TotalSum += i;
            Console.Write(i + " ");
        }
        Console.WriteLine();   
        Console.WriteLine($"Sum: {TotalSum}");









    }
}