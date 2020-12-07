using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1
            Console.WriteLine("Part 1");
            var rules = File.ReadAllLines("input.txt").Select(x => new Rule(x)).ToList();
            var set = new HashSet<string>();
            var bagType = "shiny gold";
            AddPossibleCombinationsToHashSet(bagType, rules, set);
            Console.WriteLine($"Number of combinations = {set.Count}");
            // Part 2
            Console.WriteLine("Part 2");
            var count = CountHowManyBagsInProvidedBagType(bagType, rules);
            Console.WriteLine($"Number of bags in {bagType} = {count}");
        }

        static void AddPossibleCombinationsToHashSet(string bagType, ICollection<Rule> rules, HashSet<string> checkedBags)
        {
            foreach (var rule in rules.Where(x => x.Content.ContainsKey(bagType)))
            {
                if (checkedBags.Contains(rule.BagType))
                    continue;
                
                checkedBags.Add(rule.BagType);
                AddPossibleCombinationsToHashSet(rule.BagType, rules, checkedBags);
            }
        }

        static int CountHowManyBagsInProvidedBagType(string bagType, ICollection<Rule> rules)
        {
            var sum = 0;
            foreach (var (type, count) in rules.First(x => x.BagType == bagType).Content)
            {
                sum += count + count * CountHowManyBagsInProvidedBagType(type, rules);
            }
            return sum;
        }
    }


}
