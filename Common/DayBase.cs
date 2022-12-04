using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Common
{
    public abstract class DayBase
    {
        private int Day { get; }
        private int Year { get; }
        protected string Title { get; }
        protected List<string> Input => LoadInput();

        private List<string> LoadInput()
        {
            var filePath = Path.GetRelativePath(Environment.CurrentDirectory, $"Inputs/day{Day}.txt");
            var lines = File.ReadAllLines(filePath);

            return lines.ToList();
        }
        
        private protected  DayBase(int day, int year, string title)
        {
            Day = day;
            Year = year;
            Title = title;
        }

        public abstract void Play();
    }
}