using System;
using System.Text.RegularExpressions;
namespace Day8
{
    public class InstructionFactory
    {
        private static readonly Regex _instructionRegex = new Regex(@"(?<instructionType>[^ ]*) (?<value>.\d+)");
        public static Instruction Create(string instruction)
        {
            var match = _instructionRegex.Match(instruction);
            var instructionType = match.Groups["instructionType"].Value;
            var value = int.Parse(match.Groups["value"].Value);

            return instructionType switch 
            {
                "nop" => new NoOpInstruction(value),
                "acc" => new AccumulatorInstruction(value),
                "jmp" => new JumpInstruction(value),
                _ => throw new NotImplementedException($"Instruction {instruction} is not supported")
            };
        }
    }
}