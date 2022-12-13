using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day12 : DayBase
    {
        internal Day12() : base(12, 2022, "Hill Climbing Algorithm")
        {
        }

        public override void Play()
        {
            var startIndex = (0,0);
            var endIndex = (0,0);
            var row = 0;
            foreach (var line in Input)
            {
                var indexOfS = line.IndexOf("S");
                var indexOfE = line.IndexOf("E");
                if (indexOfS != -1)
                {
                    startIndex = (row,indexOfS);
                }

                if (indexOfE != -1)
                {
                    endIndex = (row, indexOfE);
                }
                row++;
            }
            var elevationMap = Utility.CreateMatrix<string>(Input);
            
            for (var i = 0; i < elevationMap.GetLength(0); i++)
            {
                for (var j = 0; j < elevationMap.GetLength(1); j++)
                {
                    if (elevationMap[i, j] == "S")
                    {
                        elevationMap[i, j] = "a";
                    }

                    if (elevationMap[i, j] == "E")
                    {
                        elevationMap[i, j] = "z";
                    }
                }
            }

            var queue = new Queue<(int, int)>();
            queue.Enqueue(startIndex);
            var visited = new HashSet<(int, int)>();
            var path = new Dictionary<(int, int), (int, int)>();
            var found = false;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current == endIndex)
                {
                    found = true;
                    break;
                }

                var neighbors = GetNeighbors(current, elevationMap);
                foreach (var neighbor in neighbors)
                {
                    if (visited.Contains(neighbor)) continue;
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                    path[neighbor] = current;
                }
            }
            
            if (found)
            {
                var current = endIndex;
                var pathLength = 0;
                while (current != startIndex)
                {
                    current = path[current];
                    pathLength++;
                }
                Console.Write($"{GetType().Name} : {Title} -- Path length from start to end: {pathLength} steps.");
            }
            
            var queue2 = new Queue<(int, int)>();
            queue2.Enqueue(endIndex);
            var visited2 = new HashSet<(int, int)>();
            var path2 = new Dictionary<(int, int), (int, int)>();
            var newStart = (0,0);
            var found2 = false;
            while (queue2.Count > 0)
            {
                var current = queue2.Dequeue();
                if (visited2.Contains(current))
                {
                    continue;
                }
                
                visited2.Add(current);
                if (elevationMap[current.Item1, current.Item2] == "a")
                {
                    newStart = (current.Item1, current.Item2);
                    found2 = true;
                    break;
                }
                
                var neighbors = GetNeighborsDownhill(current, elevationMap);
                foreach (var neighbor in neighbors)
                {
                    if (visited2.Contains(neighbor)) continue;
                    queue2.Enqueue(neighbor);
                    path2[neighbor] = current;
                }
            }
            
            if (found2)
            {
                var current = newStart;
                var steps = 0;
                while (current != endIndex)
                {
                    current = path2[current];
                    steps++;
                }
                Console.WriteLine($" Shortest starting point that could be found requires: {steps} steps.");
            }
        }

        private IEnumerable<(int, int)> GetNeighbors((int, int) current, string[,] elevationMap)
        {
            var (row, col) = current;
            var neighbors = new List<(int, int)>();

            if (row > 0 &&  (Encoding.ASCII.GetBytes(elevationMap[row - 1, col])[0] <= Encoding.ASCII.GetBytes(elevationMap[row, col])[0] + 1))
            {
                neighbors.Add((row - 1, col));
            }

            if (row < elevationMap.GetLength(0) - 1 && (Encoding.ASCII.GetBytes(elevationMap[row + 1, col])[0] <= Encoding.ASCII.GetBytes(elevationMap[row, col])[0] + 1))
            {
                neighbors.Add((row + 1, col));
            }

            if (col > 0 &&  (Encoding.ASCII.GetBytes(elevationMap[row, col - 1])[0] <= Encoding.ASCII.GetBytes(elevationMap[row, col])[0] + 1))
            {
                neighbors.Add((row, col - 1));
            }

            if (col < elevationMap.GetLength(1) - 1 &&  (Encoding.ASCII.GetBytes(elevationMap[row, col + 1])[0] <= Encoding.ASCII.GetBytes(elevationMap[row, col])[0] + 1))
            {
                neighbors.Add((row, col + 1));
            }

            return neighbors;
        }
        
        private IEnumerable<(int, int)> GetNeighborsDownhill((int, int) current, string[,] elevationMap)
        {
            var (row, col) = current;
            var neighbors = new List<(int, int)>();

            if (row > 0 &&  (Encoding.ASCII.GetBytes(elevationMap[row - 1, col])[0] >= Encoding.ASCII.GetBytes(elevationMap[row, col])[0] - 1))
            {
                neighbors.Add((row - 1, col));
            }

            if (row < elevationMap.GetLength(0) - 1 && (Encoding.ASCII.GetBytes(elevationMap[row + 1, col])[0] >= Encoding.ASCII.GetBytes(elevationMap[row, col])[0] - 1))
            {
                neighbors.Add((row + 1, col));
            }

            if (col > 0 &&  (Encoding.ASCII.GetBytes(elevationMap[row, col - 1])[0] >= Encoding.ASCII.GetBytes(elevationMap[row, col])[0] - 1))
            {
                neighbors.Add((row, col - 1));
            }

            if (col < elevationMap.GetLength(1) - 1 &&  (Encoding.ASCII.GetBytes(elevationMap[row, col + 1])[0] >= Encoding.ASCII.GetBytes(elevationMap[row, col])[0] - 1))
            {
                neighbors.Add((row, col + 1));
            }

            return neighbors;
        }
    }
}