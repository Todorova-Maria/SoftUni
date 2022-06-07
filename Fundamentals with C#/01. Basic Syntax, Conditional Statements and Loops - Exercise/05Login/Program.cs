using System;

 class Program
{
     static void Main(string[] args)
    {
        var name = Console.ReadLine();

        string pass = string.Empty;


        for (int i = name.Length - 1; i >= 0; i--)
        {
            pass += name[i];

        }


        var input = Console.ReadLine();
        int count = 0;
        while (input != pass) {
             
            count++;
            if (count == 4)
            {
                Console.WriteLine($"User {name} blocked!");
                return;
            }
            else if (count < 4)
            {
                Console.WriteLine("Incorrect password. Try again.");
            }
            input = Console.ReadLine();
        }
        Console.WriteLine($"User {name} logged in.");

    }
}


