using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day5 : DayBase
    {
        internal Day5() : base(5, 2022, "Supply Stacks"){}

        private const char EmptyChar = (char)32;

        public override void Play()
        {
            
            var packageRowsFifo = (from line in Input
                where !line.StartsWith("move")
                select line.Replace("[", " ")
                    .Replace("]", " ")
                into characters
                select characters.ToList()).ToList();
            
            var packageRowsLifo = packageRowsFifo.Select(row => row.ToList()).ToList();

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
                    var fromIndex = packageRowsFifo.FindIndex(row => row[from] != EmptyChar);
                    var fromIndexCopy = packageRowsLifo.FindIndex(row => row[from] != EmptyChar);
                    var newFifoRow = MovePackage( to, packageRowsFifo, fromIndex, @from);
                    var newLifoRow = MovePackage(to, packageRowsLifo, fromIndexCopy, @from);
                    packageRowsFifo.Insert(0, newFifoRow);
                    packageRowsLifo.Insert(numberOfPackagesToLift, newLifoRow);
                    numberOfPackagesToLift++;
                    numberOfMoves--;
                }
            }
            
            Console.WriteLine($"{GetType().Name}: {Title} --- First Order Top Packages: {TopRowPackages(packageRowsFifo)}. Second Order Top Packages: {TopRowPackages(packageRowsLifo)}");

        }

        private static List<char> MovePackage(int to,
            IReadOnlyList<List<char>> packageRowsInput, int fromIndex, int @from)
        {
            var newPackageRows = new List<char>();
            for (var i = 0; i < 35; i++)
            {
                newPackageRows.Add(EmptyChar);
            }

            newPackageRows.Insert(to, packageRowsInput[fromIndex][@from]);
            packageRowsInput[fromIndex][@from] = EmptyChar;
            return newPackageRows;
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
                var packageIndex = packageRows.FindIndex(row => row[packageLineIndex] != EmptyChar);
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