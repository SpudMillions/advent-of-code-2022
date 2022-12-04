using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day1
{
    internal class CalorieCounting
    {
        private List<int> CreateElfList(List<string> calorieLog)
        {
            var elfList = new List<int>();
            var currentCalories = 0;

            foreach (var logEntry in calorieLog)
            {
                if (logEntry.Length > 0)
                {
                    currentCalories += Int32.Parse(logEntry);
                }
                else
                {
                    elfList.Add(currentCalories);
                    currentCalories = 0;
                }
            }
            return elfList;
        }


        internal void Play()
        {
            List<string> calorieLog = InputLoader.LoadData("day1.txt", "1");

            var elfList = CreateElfList(calorieLog);
            elfList.Sort();
            var firstEntry = elfList[^1];
            var lastThreeEntries = elfList.GetRange(elfList.Count - 3, 3).Sum();

            Console.WriteLine($"Day1: Max calorie entry: {firstEntry}, Top three elves: {lastThreeEntries}");
        }
    }
}