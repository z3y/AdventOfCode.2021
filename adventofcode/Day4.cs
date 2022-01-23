using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class Day4
{
    public static void Part2()
    {
        var input = File.ReadAllLines(Program.GetInputPath("Day4.txt"));
        var bingoNumbers = input[0].Split(',').Select(int.Parse).ToArray();
        var boards = new List<Dictionary<int, bool>>();

        for (int i = 2; i < input.Length - 4; i += 6)
        {
            if (i % 6 == 0) continue;
            var numbers = new List<int>();
            for (int j = 0; j < 5; j++)
            {
                var values = input[i + j].Split(' ').Where(x => !x.Equals(string.Empty)).Select(int.Parse).ToArray();
                numbers.AddRange(values);
            }

            boards.Add(numbers.ToDictionary(x => x, _ => false));
        }

        var winningNumber = 0;
        var winningBoard = 0;
        var wins = new bool[boards.Count];

        for (int i = 0; i < bingoNumbers.Length; i++)
        {
            for (int j = 0; j < boards.Count; j++)
            {
                if (boards[j].ContainsKey(bingoNumbers[i]))
                {
                    boards[j][bingoNumbers[i]] = true;
                }

                var verticalWin = 0;
                for (int k = 0; k < boards[j].Count; k++)
                {
                    if (k % 5 == 0)
                    {
                        verticalWin = 0;
                    }

                    if (boards[j].ElementAt(k).Value)
                    {
                        verticalWin++;
                    }

                    if (verticalWin == 5)
                    {
                        winningNumber = bingoNumbers[i];
                        wins[j] = true;
                        winningBoard = j;
                        if (wins.All(x => x))
                        {
                            goto BOARD_WON;
                        }
                    }
                }

                for (int k = 0; k < 5; k++)
                {
                    var horizontalWin = 0;
                    for (int l = 0; l < boards[j].Count; l += 5)
                    {
                        if (boards[j].ElementAt(k + l).Value)
                        {
                            horizontalWin++;
                        }

                        if (horizontalWin == 5)
                        {
                            winningNumber = bingoNumbers[i];
                            wins[j] = true;
                            winningBoard = j;
                            if (wins.All(x => x))
                            {
                                goto BOARD_WON;
                            }
                        }
                    }
                }
            }

        }

        BOARD_WON:
        var unmarkedSum = boards[winningBoard].Where(x => !x.Value).Sum(x => x.Key);
        Console.WriteLine(winningNumber * unmarkedSum);
        Console.WriteLine(unmarkedSum);
        Console.WriteLine(winningNumber);
    }
}