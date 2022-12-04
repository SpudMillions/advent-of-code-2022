using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    internal class Day1: DayBase
    {
        public Day1() : base(1, 2022, "Calorie Counting")
        {
        }

        private List<int> CreateElfList(List<string> calorieLog)
        {
            var elfList = new List<int>();
            var currentCalories = 0;

            foreach (var logEntry in calorieLog)
            {
                if (logEntry.Length > 0)
                {
                    currentCalories += int.Parse(logEntry);
                }
                else
                {
                    elfList.Add(currentCalories);
                    currentCalories = 0;
                }
            }
            return elfList;
        }


        public override void Play()
        {
            List<string> calorieLog = Input;

            var elfList = CreateElfList(calorieLog);
            elfList.Sort();
            var firstEntry = elfList[^1];
            var lastThreeEntries = elfList.GetRange(elfList.Count - 3, 3).Sum();

            Console.WriteLine($"{GetType().Name}: {Title} -- Max calorie entry: {firstEntry}, Top three elves: {lastThreeEntries}");
        }
    }
}