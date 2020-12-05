namespace Day2
{
    public interface IPasswordPolicy
    {
         bool IsValid(string password);
    }
}