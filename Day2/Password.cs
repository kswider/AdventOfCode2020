using System.Text.RegularExpressions;

namespace Day2
{
    public class Password
    {
        private static Regex _passwordRegex = new Regex(@"(?<min>\d+)-(?<max>\d+) (?<letter>.): (?<password>.*)");
        private readonly IPasswordPolicy _policy;
        private readonly string _password;

        public Password(IPasswordPolicy policy, string password)
        {
            _policy = policy;
            _password = password;
        }

        public bool IsValidPassword()
        {
            return _policy.IsValid(_password);
        }
    }
}