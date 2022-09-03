using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        int[] availableCoins = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int targetSum = int.Parse(Console.ReadLine());

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        int[] sortedCoins = coins.OrderByDescending(coin => coin).ToArray();
        Dictionary<int, int> result = new Dictionary<int, int>();

        int currSum = 0;
        int coinIndex = 0;

        while (currSum != targetSum &&  coinIndex < sortedCoins.Length)
        {
            int currCoin = sortedCoins[coinIndex];
            int reminder = targetSum - currSum;
            int numberOfCoins = reminder / currCoin;
            if (currSum + currCoin <= targetSum)
            {
                result.Add(currCoin, numberOfCoins);
                currSum += numberOfCoins * currCoin;
            }
            coinIndex++;
        } 

        if(currSum != targetSum)
        {
            throw new InvalidOperationException();
        }

        return result;
    }
}