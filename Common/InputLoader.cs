using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Common
    {
        public static class  InputLoader
        {
            public static List<string> LoadData(string fileName, string dayNumber)
            {
                var filePath = Path.Combine(Environment.CurrentDirectory, $"Day{dayNumber}/" + fileName);
                var lines = File.ReadAllLines(filePath);

                return lines.ToList();
            }
        }
    }