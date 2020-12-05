using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {   
            // Part 1
            Console.WriteLine("Part 1");
            var lines = File.ReadAllLines("./input.txt");
            var countValidWithBasicPolicy = lines.Select(x => ParsePassword(x, false)).Where(x => x.IsValidPassword()).Count();
            Console.WriteLine($"Number of valid passwords: {countValidWithBasicPolicy}");

            // Part 2
            Console.WriteLine("Part 2");
            var countValidWithAdvancedPolicy = lines.Select(x => ParsePassword(x, true)).Where(x => x.IsValidPassword()).Count();
            Console.WriteLine($"Number of valid passwords: {countValidWithAdvancedPolicy}");
        }

        static Password ParsePassword(string input, bool advancedPolicy)
        {
            var passwordRegex = new Regex(@"(?<firstDigit>\d+)-(?<secondDigit>\d+) (?<letter>.): (?<password>.*)");
            var match = passwordRegex.Match(input);
            int firstDigit = int.Parse(match.Groups["firstDigit"].Value);
            int secondDigit = int.Parse(match.Groups["secondDigit"].Value);
            char letter = char.Parse(match.Groups["letter"].Value); 
            IPasswordPolicy policy;
            if (advancedPolicy)
                policy = new OnlyOneInPositionPolicy(firstDigit, secondDigit, letter);
            else
                policy = new CountOfLettersPolicy(firstDigit, secondDigit, letter);
            return new Password(policy, match.Groups["password"].Value);           
        }
    }
}
