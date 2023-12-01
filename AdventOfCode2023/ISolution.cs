using System.Collections.Generic;

namespace AdventOfCode2023
{
    public interface ISolution
    {
        int GetDayNumber();
        
        string RunPart1(IEnumerable<string> inputLines);
        string RunPart2(IEnumerable<string> inputLines);
    }
}