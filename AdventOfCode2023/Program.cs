using System;
using System.IO;

namespace AdventOfCode2023
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var solutionsToRun = new ISolution[]
            {
                new Day1Solution()
            };

            foreach (var solution in solutionsToRun)
            {
                var day = solution.GetDayNumber();
                var inputLines = File.ReadLines($@"..\..\Input\Day{day}.txt");
                
                Console.Out.WriteLine($"{ solution.RunPart1(inputLines) }\n{ solution.RunPart2(inputLines) }\n");
            }
        }
    }
}