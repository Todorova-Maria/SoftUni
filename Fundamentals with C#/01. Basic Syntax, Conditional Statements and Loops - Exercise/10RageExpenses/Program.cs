using System;

class Program
{
    static void Main(string[] args)
    {

        var lostGamesCount = int.Parse(Console.ReadLine());
        var headsetPrice = double.Parse(Console.ReadLine());
        var mousePrice = double.Parse(Console.ReadLine());
        var keyboardPrice = double.Parse(Console.ReadLine());
        var displayPrice = double.Parse(Console.ReadLine());

        var count = 0;
        var totalSum = 0.00;

        while (count < lostGamesCount) { 
        count++;
            if (count % 2 == 0)
            {
                totalSum += headsetPrice;
            }
            if (count % 3 == 0)
            {
                totalSum += mousePrice;
            }
            if (count % 6 == 0)
            {
                totalSum += keyboardPrice;
            }

            if (count % 12 == 0)
            {
                totalSum += displayPrice;
            }
        }
        Console.WriteLine($"Rage expenses: {totalSum:F2} lv.");

        }
    
    }
