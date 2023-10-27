using System;
using AdventOfCode2022.Days.Helpers;
using static AdventOfCode2022.Days.Helpers.Day9Helper;

namespace AdventOfCode2022.Days
{
	public class Day9 : BaseDay
	{
		public Day9() 
		: base(nameof(Day9))
        //: base(nameof(Day9), Path.Combine("Inputs", "Test"))
        //: base("Day9.2", Path.Combine("Inputs", "Test"))
        {

        }

        public override string Solve1()
        {

            // Initialize.
            Position headCurrentPosition = new() { x = 0, y = 0 };
            Position tailCurrentPosition = new() { x = 0, y = 0 };
            

            HashSet<Position> visitedPositionsHashSet = new(new PositionComparer()) { tailCurrentPosition };
            var instructions = Day9Helper.GetInstructions(InputLines);

            // Process.
            foreach (var instruction in instructions)
            {
                //visitedPositionsHashSet = visitedPositionsHashSet
                //   .Concat(ProcessMovement(instruction, headCurrentPosition, tailCurrentPosition))
                //   .ToHashSet(new PositionComparer());
                visitedPositionsHashSet.UnionWith(ProcessMovement(instruction, headCurrentPosition, tailCurrentPosition, visitedPositionsHashSet));
            }

            return visitedPositionsHashSet.Count.ToString();
        }

        public override string Solve2()
        {
            // Initialize.
            Position[] headsPositions = Enumerable.Repeat(1, 10)
                .Select(_ => new Position { x = 0, y = 0 })
                .ToArray();

            Position tailPosition = new Position { x = 0, y = 0 };

            HashSet<Position> visitedPositionsHashSet = new(new PositionComparer()) { tailPosition };
            var instructions = Day9Helper.GetInstructions(InputLines);

            foreach (var instruction in instructions)
            {
                ProcessMovement(instruction, headsPositions, tailPosition, visitedPositionsHashSet);
            }

            return visitedPositionsHashSet.Count.ToString();
        }
    }
}

