using System.Linq;

namespace Day2
{
    public class CountOfLettersPolicy : IPasswordPolicy
    {
        private readonly int _min;
        private readonly int _max;
        private readonly char _letter;

        public CountOfLettersPolicy(int min, int max, char letter)
        {
            _max = max;
            _min = min;
            _letter = letter;
        }

        public bool IsValid(string password)
        {
            var countOfLettersInPasswords = password.Where(x => x == _letter).Count();
            if (countOfLettersInPasswords >= _min && countOfLettersInPasswords <= _max)
                return true;
            return false;
        }
    }
}