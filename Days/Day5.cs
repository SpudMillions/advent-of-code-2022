using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day5 : DayBase
    {
        internal Day5() : base(5, 2022, "Supply Stacks")
        {
        }

        public override void Play()
        {
            const char emptyChar = (char)32;
            var packageRows = (from line in Input
                where !line.StartsWith("move")
                select line.Replace("[", " ")
                    .Replace("]", " ")
                into characters
                select characters.ToList()).ToList();
            
            var packageRowsCopy = packageRows.Select(row => row.ToList()).ToList();

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
                var from = ConvertInputUsingOffset(command[1]);
                var to = ConvertInputUsingOffset(command[2]);
                var numberOfPackagesToLift = 0;

                while (numberOfMoves > 0)
                {
                    var newPackageRows = new List<char>();
                    var newPackageRowsCopy = new List<char>();
                    
                    var fromIndex = packageRows.FindIndex(row => row[from] != emptyChar);
                    var fromIndexCopy = packageRowsCopy.FindIndex(row => row[from] != emptyChar);
                    for (var i = 0; i < 35; i++)
                    {
                        newPackageRows.Add(emptyChar);
                        newPackageRowsCopy.Add(emptyChar);
                    }

                    newPackageRows.Insert(to, packageRows[fromIndex][from]);
                    newPackageRowsCopy.Insert(to, packageRowsCopy[fromIndexCopy][from]);
                    packageRows[fromIndex][from] = emptyChar;
                    packageRowsCopy[fromIndex][from] = emptyChar;
                    packageRows.Insert(0, newPackageRows); 
                    packageRowsCopy.Insert(0 + numberOfPackagesToLift, newPackageRowsCopy);
                    numberOfPackagesToLift += 1;
                    numberOfMoves -= 1;
                }
            }
            var topRowPackages = TopRowPackages(packageRows);
            var packageRowsCopyPackages = TopRowPackages(packageRowsCopy);
            
            Console.WriteLine($"{GetType().Name}: {Title} --- First Order Top Packages: {topRowPackages}. Second Order Top Packages: {packageRowsCopyPackages}");

        }

        private static int ConvertInputUsingOffset(string command)
        {
            return int.Parse(command) * 4 - 3;
        }

        private static string TopRowPackages(List<List<char>> packageRows)
        {
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

            return topRowPackages;
        }
    }
}