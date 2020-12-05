namespace Day2
{
    public class OnlyOneInPositionPolicy : IPasswordPolicy
    {
        private readonly int _position1;
        private readonly int _position2;
        private readonly char _letter;
        public OnlyOneInPositionPolicy(int position1, int position2, char letter)
        {
            _position1 = position1;
            _position2 = position2;
            _letter = letter;
        }

        public bool IsValid(string password)
        {
            if (password[_position1 - 1] == _letter && password[_position2 - 1] != _letter ||
                password[_position1 - 1] != _letter && password[_position2 - 1] == _letter)
                return true;
            return false;
        }
    }
}