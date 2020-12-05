using System;
using System.IO;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1
            Console.WriteLine("Part 1");
            var passwordsAsStrings = File.ReadAllText("input.txt").Split(new string[] { "\n\n" },
                               StringSplitOptions.RemoveEmptyEntries).ToList();

            var countOfValidPasswords = passwordsAsStrings.Select(x =>
            {
                var basicPassportFiller = new BasicPassportFiller(x);
                return Passport.CreateAndFillPassport(basicPassportFiller);

            }).Where(x => x.IsValid()).Count();    

            Console.WriteLine($"Count of valid passwords = {countOfValidPasswords}");

            // Part 2
            Console.WriteLine("Part 2");
            countOfValidPasswords = passwordsAsStrings.Select(x =>
            {
                var advancedFiller = new AdvancedPassportFiller(x);
                return Passport.CreateAndFillPassport(advancedFiller);

            }).Where(x => x.IsValid()).Count();    

            Console.WriteLine($"Count of valid passwords = {countOfValidPasswords}");
        }
    }
}
