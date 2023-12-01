using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2023
{
    public class Day1Solution : ISolution
    {
        public int GetDayNumber()
        {
            return 1;
        }

        public string RunPart1(IEnumerable<string> inputLines)
        {
            return inputLines
                .Select(line => line.Where(char.IsDigit))
                .Select(line => 10 * CharToInt(line.First()) + CharToInt(line.Last()))
                .Sum().ToString();
            
            int CharToInt(char c) => c - '0';
        }

        public string RunPart2(IEnumerable<string> inputLines)
        {
            var numberLookup = new Dictionary<string, int>
            {
                { "0", 0 },
                { "1", 1 },
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "zero", 0 },
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }
            };

            return (from line in inputLines
                let startValue = numberLookup.Aggregate(new KeyValuePair<int, int>(int.MaxValue, 0), (accumulatorPair, lookupEntry) => 
                    NonNegativeIndexOf(line, lookupEntry.Key) < accumulatorPair.Key
                        ? new KeyValuePair<int, int>(NonNegativeIndexOf(line, lookupEntry.Key), lookupEntry.Value)
                        : accumulatorPair)
                    .Value
                let endValue = numberLookup.Aggregate(new KeyValuePair<int, int>(int.MinValue, 0), (accumulatorPair, lookupEntry) => 
                    line.LastIndexOf(lookupEntry.Key) > accumulatorPair.Key
                        ? new KeyValuePair<int, int>(line.LastIndexOf(lookupEntry.Key), lookupEntry.Value)
                        : accumulatorPair)
                    .Value
                select 10 * startValue + endValue)
                .Sum().ToString();
            
            int NonNegativeIndexOf(string haystack, string needle)
            {
                var index = haystack.IndexOf(needle);
                return index == -1 ? int.MaxValue : index;
            }
        }
    }
}