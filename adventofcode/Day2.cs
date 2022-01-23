
using System;
using System.IO;

public class Day2
{
    static string[] Input = File.ReadAllLines(Program.GetInputPath("Day2.txt"));
    public static void Part2()
    {
        int forward = 0;
        int depth = 0;
        int aim = 0;

        foreach (var i in Input)
        {
            var unit = i[^1] - '0';
            if (i[0] == 'f')
            {
                forward += unit;
                depth += aim * unit;
            }
            else if (i[0] == 'u')
            {
                aim -= unit;
            }
            else
            {
                aim += unit;
            }
        }
        
        Console.WriteLine(depth * forward);
    }
}
