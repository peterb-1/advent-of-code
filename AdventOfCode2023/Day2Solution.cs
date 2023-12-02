using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2023
{
    public class Day2Solution : ISolution
    {
        public int GetDayNumber()
        {
            return 2;
        }

        public string RunPart1(IEnumerable<string> inputLines)
        {
            return inputLines
                .Select(line => line.Split(',', ':', ';'))
                .Where(line => line.All(ValidateEntry))
                .Sum(GetLineNumber)
                .ToString();
            
            bool ValidateEntry(string entry) =>
                entry.Contains("Game") || 
                ValidateColourEntry("red", entry, 12) || 
                ValidateColourEntry("green", entry, 13) || 
                ValidateColourEntry("blue", entry, 14);

            bool ValidateColourEntry(string colour, string entry, int max) => entry.Contains(colour) && GetEntryCount(entry) <= max;

            int GetLineNumber(string[] line) => int.Parse(line[0].Substring(5));
        }

        public string RunPart2(IEnumerable<string> inputLines)
        {
            return inputLines
                .Select(line => GetMinPossibleProduct(line.Split(',', ':', ';')))
                .Sum().ToString();
            
            int GetMinPossibleProduct(string[] line) => 
                GetMinPossibleCount("red", line) * GetMinPossibleCount("green", line) * GetMinPossibleCount("blue", line);

            int GetMinPossibleCount(string colour, string[] line) => 
                line.Aggregate(0, (accumulator, entry) => entry.Contains(colour) ? Math.Max(accumulator, GetEntryCount(entry)) : accumulator);
        }

        private static int GetEntryCount(string entry) => int.Parse(entry.Substring(0, 3).Trim(' '));
    }
}