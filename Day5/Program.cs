using System.Collections;
using System.IO;
using System;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1
            Console.WriteLine("Part 1");
            
            const int numberOfRows = 128;
            const int numberOfColumns = 8;
            const int factor = 8;

            var seatIds = File.ReadAllLines("input.txt")
                .Select( x => CalculateSeatId(x, numberOfRows, numberOfColumns, factor));

            Console.WriteLine($"Max = {seatIds.Max()}");

            // Part 2
            Console.WriteLine("Part 2");
            var min = seatIds.Min();
            var max = seatIds.Max();
            var range = Enumerable.Range(min, max - min);
            var seatId = range.Except(seatIds).First();
            Console.WriteLine($"SeatId = {seatId}");

        }

        private static int CalculateSeatId(string input, int numberOfRows, int numberOfColumns, int factor)
        {
            var row = CalculateRow(input.Substring(0,7), numberOfRows);
            var column = CalculateColumn(input.Substring(7), numberOfColumns);
            return row * factor + column; 
        }

        private static int CalculateRow(string input, int numberOfRows)
        {
            return CalculateNumber(input, numberOfRows, 'F', 'B');
        }

        private static int CalculateColumn(string input, int numberOfColumns)
        {
            return CalculateNumber(input, numberOfColumns, 'L', 'R');
        }

        private static int CalculateNumber(string input, int maxNumber, char characterForFront, char characterForBack)
        {
            var current = maxNumber / 2;
            var divider = maxNumber / 4;
            foreach (var letter in input)
            {
                if (letter == characterForFront)
                    current -= divider;
                if (letter == characterForBack)
                    current += divider;

                divider /= 2;
            }
            
            return input.Last() == characterForFront ? current - 1 : current;
        }
    }
}
