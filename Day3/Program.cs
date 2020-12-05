using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = File.ReadAllLines("input.txt");

            // Part 1
            Console.WriteLine("Part 1");
            var firstSlope = (3, 1);
            
            var countOfTrees = CountTrees(map, firstSlope);
            Console.WriteLine($"Count of trees = {countOfTrees}");
            // Part 2
            Console.WriteLine("Part 2");
            var slopesToCheck = new List<(int, int)>
            {
                (1,1),
                (3,1),
                (5,1),
                (7,1),
                (1,2)
            };

            BigInteger multipliedTrees = 1;
            foreach (var slope in slopesToCheck)
            {
                countOfTrees = CountTrees(map, slope);
                multipliedTrees *= countOfTrees;
            }
            Console.WriteLine($"MultipliedTrees = {multipliedTrees}");
        }
        
        static private int CountTrees(string[] map, (int moveX, int moveY) slope)
        {
            var Tree = '#';
            var widthOfTheMap = map[0].Length;
            var currentX = 0;
            var currentY = 0;
            var countOfTrees = 0;
            while (currentY < map.Length)
            {
                if (map[currentY][currentX] == Tree)
                    countOfTrees++;

                (currentX, currentY) = Move(currentX, currentY, slope, widthOfTheMap);
            }
            return countOfTrees;
        }

        static private (int, int) Move(int x, int y, (int moveX, int moveY) slope, int widthOfTheMap)
        {
            int newX = (x + slope.moveX) % widthOfTheMap;
            int newY = y + slope.moveY;
            return (newX, newY);
        }
    }
}
