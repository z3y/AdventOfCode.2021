
using System;
using System.IO;
using System.Linq;

public class Day1
{
    static int[] Input = File.ReadAllLines(Program.GetInputPath("Day1.txt")).Select(int.Parse).ToArray();
    public static void Part1()
    {
        var increasedAmount = 0;
        for (int i = 1; i < Input.Length; i++)
        {
            unsafe
            {
                bool hasIncreased = Input[i] > Input[i - 1];
                increasedAmount += *(byte*)&hasIncreased;
            }
        }
        
        Console.WriteLine(increasedAmount);
    }
    
    public static void Part2()
    {
        var increasedAmount = 0;
        var previousSum = 0;
        for (int i = 0; i < Input.Length - 3; i++)
        {
            int sum = Input[i] + Input[i + 1] + Input[i + 2];
            unsafe
            {
                bool hasIncreased = sum > previousSum;
                increasedAmount += *(byte*)&hasIncreased;
            }
            previousSum = sum;
        }
        
        Console.WriteLine(increasedAmount);
    }
    
}
