using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1
            Console.WriteLine("Part 1");
            var groups = File.ReadAllText("input.txt").Split(new string[] { "\n\n" },
                               StringSplitOptions.RemoveEmptyEntries);
            var sumAnyAnsweredYes = 0;
            foreach (var group in groups)
            {
                var set = new HashSet<char>();
                foreach (var letter in group)
                    if (char.IsLetter(letter))
                        set.Add(letter);
                sumAnyAnsweredYes += set.Count;
            }
            Console.WriteLine($"Sum of questions where anyone from group answered 'yes' = {sumAnyAnsweredYes}");
            
            // Part 2
            Console.WriteLine("Part 2");
            var sumEveryoneAnsweredYes = 0;
            foreach (var group in groups)
            {
                var numberOfPeopleInGroup = group.Split("\n").Length;
                var dictionary = new Dictionary<char, int>();
                foreach (var letter in group)
                {
                    if (char.IsLetter(letter))
                    {
                        if (dictionary.ContainsKey(letter))
                            dictionary[letter]++;
                        else
                            dictionary.Add(letter, 1);
                    }
                }
                sumEveryoneAnsweredYes += dictionary.Where(x => x.Value == numberOfPeopleInGroup).Count();
            }
            Console.WriteLine($"Sum of questions where everyone from group answered 'yes' = {sumEveryoneAnsweredYes}");
        }
    }
}
