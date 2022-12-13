using System;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day8: DayBase
    {
        internal Day8() : base(8, 2022, "Treetop Tree House")
        {
        }

        public override void Play()
        {
            var forest = Utility.CreateMatrix<int>(Input);
            var length = forest.GetLength(1);
            var width = forest.GetLength(0);
            
            var count = 0;
            var bestTreeSpotCount = 0;
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    if (IsTreeVisible(forest, i, j))
                    {
                        count++;
                    }

                    if (i == 0 || j == 0 || i == width - 1 || j == length - 1) continue;
                    bestTreeSpotCount = BestTreeSpotCount(j, length, forest, i, width, bestTreeSpotCount);
                }
            }
            
            Console.WriteLine($"{GetType().Name} : {Title} --- There are {count} trees visible. The best tree spot has {bestTreeSpotCount} trees visible.");
        }

        private int BestTreeSpotCount(int j, int length, int[,] forest, int i, int width, int bestTreeSpotCount)
        {
            var topTreeSpotCount = 0;
            var leftTreeSpotCount = 0;
            var rightTreeSpotCount = 0;
            var bottomTreeSpotCount = 0;
            var currentHeight = forest[i, j];
            
            for (var k = j + 1; k < length; k++)
            {
                rightTreeSpotCount++;
                if (forest[i, k] >= currentHeight)
                {
                    break;
                }
            }

            for (var k = j - 1; k >= 0; k--)
            {
                leftTreeSpotCount++;
                if (forest[i, k] >= currentHeight)
                {
                    break;
                }
            }

            for (var k = i - 1; k >= 0; k--)
            {
                topTreeSpotCount++;
                if (forest[k, j] >= currentHeight)
                {
                    break;
                }
            }

            for (var k = i + 1; k < width; k++)
            {
                bottomTreeSpotCount++;
                if (forest[k, j] >= currentHeight)
                {
                    break;
                }
            }

            if ((topTreeSpotCount * leftTreeSpotCount * rightTreeSpotCount * bottomTreeSpotCount) >
                bestTreeSpotCount)
            {
                bestTreeSpotCount = topTreeSpotCount * leftTreeSpotCount * rightTreeSpotCount * bottomTreeSpotCount;
            }

            return bestTreeSpotCount;
        }

        private bool IsTreeVisible(int[,] forest, int i, int i1)
        {
            var value = forest[i, i1];
            var left = true;
            var right = true;
            var up = true;
            var down = true;
    
            for (var j = 1; j < forest.GetLength(0); j++)
            {
                if (i - j >= 0)
                {
                    if (forest[i - j, i1] >= value)
                    {
                        up = false;
                    }
                }
                if (i + j < forest.GetLength(0))
                {
                    if (forest[i + j, i1] >= value)
                    {
                        down = false;
                    }
                }
                if (i1 - j >= 0 && forest[i, i1 - j] >= value)
                {
                    left = false;
                }
                if (i1 + j < forest.GetLength(1) && forest[i, i1 + j] >= value)
                {
                    right = false;
                }
            }

            var result = left || right || up || down;
            return result;            
        }
    }
}