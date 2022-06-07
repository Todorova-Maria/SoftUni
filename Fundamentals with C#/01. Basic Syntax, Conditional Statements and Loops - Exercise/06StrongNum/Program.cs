using System;

class Program
{
    static void Main(string[] args)

    {
        int n = int.Parse(Console.ReadLine());
        string number = "";
        number += n;
        int correctNum = n;
        int sumFact = 0;



        for (int i = 1; i <= number.Length; i++)
        {
            int currentnum = correctNum % 10;
            correctNum = (correctNum - currentnum) / 10;

            int fact = 1;



            for (int j = 1; j <= currentnum; j++)
            {
                fact *= j;
            }

            sumFact += fact;
        }
        if (sumFact == n)
        {
            Console.WriteLine("yes");
        } 
        else
        {
            Console.WriteLine("no");
        }
    }    


    }
    

