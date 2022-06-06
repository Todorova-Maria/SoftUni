using System;

public class Program
{
    public static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        var type = Console.ReadLine();
        var day = Console.ReadLine();

        var totalmoney = 0.0;

        
       if (type.Equals("Students"))
        {
            if (day.Equals("Friday"))
            {
                totalmoney = num * 8.45;
            } else if (day.Equals("Saturday"))
            {
                totalmoney = num * 9.80;
            }
            else if (day.Equals("Sunday"))
            {
                totalmoney = num * 10.46;
            }
            if (num >= 30)
            {
                totalmoney = totalmoney * 0.85;
            }
         
        }

        if (type.Equals("Business"))
        {
            if (day.Equals("Friday"))
            {
                totalmoney = num * 10.90;
                if (num >= 100)
                {
                    totalmoney = (num - 10) * 10.90;
                }
            }
            else if (day.Equals("Saturday"))
            {
                totalmoney = num * 15.60;
                if (num >= 100)
                {
                    totalmoney = (num - 10) * 15.60;
                }
            }
            else if (day.Equals("Sunday"))
            {
                totalmoney = num * 16.00;
            
                if (num >= 100)
                {
                    totalmoney = (num - 10) * 16.00;
                }
            }
         
        }

        if (type.Equals("Regular"))
        {
            if (day.Equals("Friday"))
            {
                totalmoney = num * 15.00;
            }
            else if (day.Equals("Saturday"))
            {
                totalmoney = num * 20.00;
            }
            else if (day.Equals("Sunday"))
            {
                totalmoney = num * 22.50;
            }
            if (num >= 10 && num <= 20)
            {
                totalmoney = totalmoney * 0.95;
            }

        }
        Console.WriteLine($"Total price: {totalmoney:F2}");

    }
}