using System;
using System.Collections.Generic;

namespace AdventOfCode.Common
{
    public static class Utility
    {
        public static T[,] CreateMatrix<T>(List<string>? input)
        {
            if (input == null) return new T[,] { };
            var grid = new T[input.Count, input[0].Length];
            var lineNumber = 0;
            
            foreach (var line in input)
            {
                var characterNumber = 0;
                foreach (var s in line)
                {
                    grid[lineNumber, characterNumber] = (T)Convert.ChangeType(s, typeof(T));
                    characterNumber++;
                }

                lineNumber++;
            }

            return grid;
        }
    }
}