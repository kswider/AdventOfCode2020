using System;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1
            Console.WriteLine("Part 1");
            var sumToFind = 2020;
            var orderedNumbers = File.ReadAllLines("./input.txt").Select(x => int.Parse(x)).OrderBy(x => x).ToList();
            for (int i = 0, j = orderedNumbers.Count - 1; i < j;)
            {
                var firstNumber = orderedNumbers[i];
                var secondNumber = orderedNumbers[j];
                var sum = firstNumber + secondNumber;
                if (sum == sumToFind)
                {
                    Console.WriteLine($"Found numbers!");
                    Console.WriteLine($"{firstNumber} + {secondNumber} = {sum}");
                    Console.WriteLine($"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
                    break;
                }
                if (sum < sumToFind)
                    i++;
                if (sum > sumToFind)
                    j--;
            }

            // Part 2
            Console.WriteLine("Part 2");
            var isSolutionFound = false;
            for (int pinned = 0; !isSolutionFound && pinned < orderedNumbers.Count; pinned++)
            {
                for (int i = 0, j = orderedNumbers.Count - 1; i < j;)
                {
                    if (i == pinned)
                    {
                        i++;
                        continue;
                    }
                    if (j == pinned)
                    {
                        j--;
                        continue;
                    }

                    var firstNumber = orderedNumbers[i];
                    var secondNumber = orderedNumbers[j];
                    var pinnedNumber = orderedNumbers[pinned];
                    var sum = firstNumber + secondNumber + pinnedNumber;
                    if (sum == sumToFind)
                    {
                        Console.WriteLine($"Found numbers!");
                        Console.WriteLine($"{firstNumber} + {secondNumber} + {pinnedNumber} = {sum}");
                        Console.WriteLine($"{firstNumber} * {secondNumber} * {pinnedNumber} = {firstNumber * secondNumber * pinnedNumber}");
                        isSolutionFound = true;
                        break;
                    }
                    if (sum < sumToFind)
                        i++;
                    if (sum > sumToFind)
                        j--;
                }
            }
        }
    }
}
