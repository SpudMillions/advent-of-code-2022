using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day5 : DayBase
    {
        internal Day5() : base(5, 2022, "TBD")
        {
        }

        public override void Play()
        {
            var packageRows = (from line in Input
                where !line.StartsWith("move")
                select line.Replace("[", " ")
                    .Replace("]", " ")
                into characters
                select characters.ToList()).ToList();

            foreach (var command in from line in Input
                where line.StartsWith("move")
                select line
                    .Replace("move ", "")
                    .Replace("from ", "")
                    .Replace("to ", "")
                    .Replace(" ", ",")
                    .Split(","))
            {
                var numberOfMoves = int.Parse(command[0]);
                var levelToStore = numberOfMoves;
                var from = int.Parse(command[1]) * 4 - 3;
                var to = int.Parse(command[2]) * 4 - 3;

                while (numberOfMoves > 0)
                {
                    var newPackageRows = new List<char>();
                    var fromIndex = packageRows.FindIndex(row => row[from] != 32);

                    for (var i = 0; i < 35; i++)
                    {
                        newPackageRows.Add((char)32);
                    }

                    newPackageRows.Insert(to, packageRows[fromIndex][from]);
                    packageRows[fromIndex][from] = (char)32;
                    packageRows.Insert(0, newPackageRows); 
                    numberOfMoves -= 1;
                }
            }
            var topRowPackages = "";
            var packageLineIndex = 1;
            while (packageLineIndex < 34)
            {
                var packageIndex = packageRows.FindIndex(row => row[packageLineIndex] != 32);
                if (packageIndex != -1)
                {
                    topRowPackages += packageRows[packageIndex][packageLineIndex];
                }

                packageLineIndex += 4;
            }
            
            Console.WriteLine(topRowPackages);
            
        }
    }
}