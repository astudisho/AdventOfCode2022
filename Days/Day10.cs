using System;
using AdventOfCode2022.Days.Helpers;

namespace AdventOfCode2022.Days
{
	public class Day10 : BaseDay
	{
        public Day10()
            : base(nameof(Day10), "Inputs")
        {
        }

        public override string Solve1()
        {
            var instructions = Day10Helper.GetInstructions(InputLines);
            var maxCycle = 220;
            var currentCycle = 1;
            var initialCycle = 20;
            var stepCycle = 40;
            var nextCheckCycle = initialCycle;
            var accumulator = 0;
            var xRegister = 1;

            for (int i = 0; i < instructions.Length; i++)
            {
                var currentInstruction = instructions[i];

                currentCycle = CheckInstruction(currentInstruction, currentCycle);
            }

            return accumulator.ToString();

            int CheckInstruction(Instruction currentInstruction, int currentCycle)
            {
                currentInstruction.CyclesLeft--;

                if (currentCycle == nextCheckCycle)
                {
                    accumulator += xRegister * currentCycle;

                    nextCheckCycle += stepCycle;
                }
                currentCycle++;

                if (currentInstruction.CyclesLeft > 0)
                    currentCycle = CheckInstruction(currentInstruction, currentCycle);
                else
                    xRegister += currentInstruction.Value;

                return currentCycle;
            }
        }

        public override string Solve2()
        {
            throw new NotImplementedException();
        }
    }
}

