namespace Day8
{
    public abstract class Instruction
    {
        public int Value { get; set; }

        public Instruction(int value)
        {
            Value = value;
        }
    }
}