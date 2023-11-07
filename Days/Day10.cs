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
            var currentCycle = 1;
            var initialCycle = 20;
            var stepCycle = 40;
            var nextCheckCycle = initialCycle;
            var accumulator = 0;
            var xRegister = 1;

            var state = new CycleState
            {
                CurrentCycle = currentCycle,
                Accumulator = accumulator,
                XRegister = xRegister,
                NextCheckCycle = nextCheckCycle,
                StepCycle = stepCycle,
            };

            for (int i = 0; i < instructions.Length; i++)
            {
                var currentInstruction = instructions[i];

                state.CurrentCycle = CheckInstruction(currentInstruction, state, Solve1Action);
            }

            return accumulator.ToString();
        }

        public override string Solve2()
        {
            var instructions = Day10Helper.GetInstructions(InputLines);

            var state = new CycleState
            {
                CurrentCycle = 1,
                Accumulator = 0,
                XRegister = 1,
                NextCheckCycle = 20,
                StepCycle = 40,
            };

            for (int i = 0; i < instructions.Length; i++)
            {
                var currentInstruction = instructions[i];

                state.CurrentCycle = CheckInstruction(currentInstruction, state, Solve2Action);
            }

            return state.Accumulator.ToString();
        }

        private int CheckInstruction(Instruction currentInstruction, CycleState state, Action<CycleState> action)
        {
            currentInstruction.CyclesLeft--;

            action(state);

            state.CurrentCycle++;

            if (currentInstruction.CyclesLeft > 0)
                state.CurrentCycle = CheckInstruction(currentInstruction, state, action);
            else
                state.XRegister += currentInstruction.Value;

            return state.CurrentCycle;
        }

        Action<CycleState> Solve1Action => (CycleState state) =>
        {
            if (state.CurrentCycle == state.NextCheckCycle)
            {
                state.Accumulator += state.XRegister * state.CurrentCycle;

                state.NextCheckCycle += state.StepCycle;
            }
        };

        Action<CycleState> Solve2Action => (CycleState state) =>
        {
            if((state.CurrentCycle % 40) >= state.XRegister && (state.CurrentCycle % 40)<= state.XRegister + 2)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(".");
            }

            if (state.CurrentCycle % 40 == 0)
                Console.WriteLine();

            //if (state.CurrentCycle == state.NextCheckCycle)
            //{
            //    state.Accumulator += state.XRegister * state.CurrentCycle;

            //    state.NextCheckCycle += state.StepCycle;
            //}
        };

        class CycleState
        {
            public int NextCheckCycle { get; set; }
            public int Accumulator { get; set; }
            public int XRegister { get; set; }
            public int StepCycle { get; set; }
            public int CurrentCycle { get; set; }
        }
    }
}

