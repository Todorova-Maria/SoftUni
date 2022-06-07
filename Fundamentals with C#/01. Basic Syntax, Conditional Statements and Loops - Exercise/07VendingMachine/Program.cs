using System;

class Program
{
    static void Main(string[] args)

    {
        string input = Console.ReadLine();

        double coinSUM = 0;

        double nuts = 2.0;
        double water = 0.7;
        double crisps = 1.5;
        double soda = 0.8;
        double coke = 1.0;



        while (input != "Start")
        {
            double coins = double.Parse(input);
            if (coins == 0.1)
            {
                coinSUM += coins;
            }
            else if (coins == 0.2)
            {
                coinSUM += coins;
            }
            else if (coins == 0.5)
            {
                coinSUM += coins;
            }
            else if (coins == 1.0)
            {
                coinSUM += coins;
            }
            else if (coins == 2.0)
            {
                coinSUM += coins;
            }
            else
            {
                Console.WriteLine($"Cannot accept {coins}");
            }


            input = Console.ReadLine();


        }

        string products = Console.ReadLine();


        while (products != "End")
        {

            if (products == "Nuts")
            {
                if (coinSUM >= nuts)
                {
                    coinSUM -= 2.0;
                    Console.WriteLine("Purchased nuts");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
            }
            else if (products == "Water")
            {
                if (coinSUM >= water)
                {
                    coinSUM -= 0.7;
                    Console.WriteLine($"Purchased water");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

            }
            else if (products == "Crisps")
            {
                if (coinSUM >= crisps)
                {
                    coinSUM -= 1.5;
                    Console.WriteLine($"Purchased crisps");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

            }
            else if (products == "Soda")
            {
                if (coinSUM >= soda)
                {
                    coinSUM -= 0.8;
                    Console.WriteLine($"Purchased soda");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

            }
            else if (products == "Coke")
            {
                if (coinSUM >= coke)
                {
                    coinSUM -= 1.0;
                    Console.WriteLine($"Purchased coke");
                }


            }
            else
            {
                Console.WriteLine("Invalid product");
            }

            products = Console.ReadLine();
           

        }
        Console.WriteLine($"Change: {coinSUM:F2}");
    }
}