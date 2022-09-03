using System;
using System.Collections.Generic;
using System.Linq;

public class SetCover
{
    public static void Main(string[] args)
    {
        int[] universe = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        int n = int.Parse(Console.ReadLine());
        List<int[]> sets = new List<int[]>();
          
        
        for (int i = 0; i < n; i++)
        {
            int[] currentSet = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            sets.Add(currentSet);
        } 

        List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");

        foreach (int[] set in selectedSets)
        {
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
        }
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        List<int[]> selectedSets = new List<int[]>();

        while (universe.Count != 0)
        {
            var currentSet = sets.OrderByDescending(set => set.Count(universe.Contains)).First();
            selectedSets.Add(currentSet);
            sets.Remove(currentSet);

            foreach (var set in currentSet)
            {
                universe.Remove(set);
            }
        }
        return selectedSets;
    }
}
