using System;
using System.Collections.Generic;

namespace Day8
{
    public class Processor
    {
        public (bool InfiniteLoop, int AccumulatorValue) ProcessInstructions(IList<Instruction> instructions)
        {
            var accumulator = 0;
            var currentInstructionNumber = 0;
            var alreadyExecutedInstructions = new HashSet<int>();
            while (true)
            {
                if (currentInstructionNumber == instructions.Count)
                    return (false, accumulator);
                if (alreadyExecutedInstructions.Contains(currentInstructionNumber))
                    return (true, accumulator);
                var instruction = instructions[currentInstructionNumber];
                alreadyExecutedInstructions.Add(currentInstructionNumber);

                switch (instruction)
                {
                    case NoOpInstruction _:
                        currentInstructionNumber++;
                        break;
                    case JumpInstruction jumpInstruction:
                        currentInstructionNumber += jumpInstruction.Value;
                        break;
                    case AccumulatorInstruction accumulatorInstruction:
                        accumulator += accumulatorInstruction.Value;
                        currentInstructionNumber++;
                        break;
                }
            }
        }
    }
}