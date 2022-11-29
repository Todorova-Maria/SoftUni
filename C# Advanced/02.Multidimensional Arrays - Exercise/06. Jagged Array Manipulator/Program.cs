using System;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[][] matrix = new int[n][];

        for (int row = 0; row < n; row++)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            matrix[row] = new int[nums.Length];
            for (int col = 0; col < nums.Length; col++)
            {
                matrix[row][col] = nums[col];
            }
        }

        for (int row = 0; row < n - 1; row++)
        {
            if (matrix[row].Length == matrix[row + 1].Length)
            { 
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (IsValid(matrix, row, col, n))
                    {
                        matrix[row][col] *= 2;
                    }
                    if (IsValid(matrix, row + 1, col, n))
                    {
                        matrix[row + 1][col] *= 2;
                    }
                }
            }
            else
            {  
                if (matrix[row].Length > matrix[row+1].Length)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (IsValid(matrix, row, col, n))
                        {
                            matrix[row][col] /= 2;
                        }
                        if (IsValid(matrix, row + 1, col, n))
                        {
                            matrix[row + 1][col] /= 2;
                        }
                    }
                } 
                else
                {
                    for (int col = 0; col < matrix[row+1].Length; col++)
                    {
                        if (IsValid(matrix, row, col, n))
                        {
                            matrix[row][col] /= 2;
                        }
                        if (IsValid(matrix, row + 1, col, n))
                        {
                            matrix[row + 1][col] /= 2;
                        }
                    }
                }
                
            }
        }

        string text = String.Empty;
        while ((text = Console.ReadLine()) != "End")
        {
            string[] arr = text.Split();
            string command = arr[0];
            int indexRow = int.Parse(arr[1]);
            int indexCol = int.Parse(arr[2]);
            int value = int.Parse(arr[3]);

            if (IsValid(matrix, indexRow, indexCol, n))
            {
                if (command == "Add")
                {
                    matrix[indexRow][indexCol] += value;
                }
                else if (command == "Subtract")
                {
                    matrix[indexRow][indexCol] -= value;
                }
            }

        }

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                Console.Write(matrix[row][col] + " ");
            }
            Console.WriteLine();
        }

    }

    public static bool IsValid(int[][] matrix, int indexRow, int indexCol, int n)
    {
        return indexRow >= 0 && indexRow < n
            && indexCol >= 0 && indexCol < matrix[indexRow].Length;
    }
}