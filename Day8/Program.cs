using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1
            Console.WriteLine("Part 1");
            var instructionSets = File.ReadAllLines("input.txt").Select(x => InstructionFactory.Create(x)).ToList();
            var processor = new Processor();
            var result = processor.ProcessInstructions(instructionSets);
            Console.WriteLine($"Accumulator = {result.AccumulatorValue}");
            
            // Part 2
            Console.WriteLine("Part 2");
            result = GetModifiedInstructionSets(instructionSets).Select(x => processor.ProcessInstructions(x)).First(x => !x.InfiniteLoop);
            Console.WriteLine($"Accumulator = {result.AccumulatorValue}");
        }

        public static IEnumerable<IList<Instruction>> GetModifiedInstructionSets(IList<Instruction> instructions)
        {
            for (var instructionCounter = 0; instructionCounter < instructions.Count; instructionCounter++)
            {
                var copyOfInstructions = new List<Instruction>(instructions);
                var instruction = instructions[instructionCounter];
                switch (instruction)
                {
                    case NoOpInstruction noOpInstruction:
                        copyOfInstructions[instructionCounter] = new JumpInstruction(noOpInstruction.Value);
                        break;
                    case JumpInstruction jumpInstruction:
                        copyOfInstructions[instructionCounter] = new NoOpInstruction(jumpInstruction.Value);
                        break;
                    case AccumulatorInstruction accumulatorInstruction:
                        break;
                }
                
                yield return copyOfInstructions;
            }
        }
    }
}
