using System.Collections.Generic;

namespace AdventOfCode.Days
{
    public class Utility
    {
        private static int[,] CreateMatrix(List<string>? input)
        {
            if (input == null) return new int[,] { };
            var forest = new int[input.Count, input[0].Length];
            var lineNumber = 0;
            
            foreach (var line in input)
            {
                var characterNumber = 0;
                foreach (var s in line)
                {
                    forest[lineNumber, characterNumber] = int.Parse(s.ToString());
                    characterNumber++;
                }

                lineNumber++;
            }

            return forest;
        }
    }
}