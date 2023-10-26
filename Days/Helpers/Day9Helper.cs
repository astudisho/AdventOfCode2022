using System;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2022.Days.Helpers
{
	public static class Day9Helper
	{
		public static IReadOnlyList<InstructionRecord> GetInstructions(string[] inputLines)
		{
			var instructions = inputLines
				.Select(line => line.Trim())
				.Select(trimedLine =>
				{
					var splitedLine = trimedLine.Split(" ");

					var instruction = splitedLine[0] switch
					{
						"R" => InstructionDirectionEnum.right,
						"L" => InstructionDirectionEnum.left,
						"U" => InstructionDirectionEnum.up,
						"D" => InstructionDirectionEnum.down,
						_ => throw new ApplicationException("Not valid instruction")
					};

					var times = int.Parse(splitedLine[1]);

					return new InstructionRecord(instruction, times);
				}).ToList();

			return instructions;
		}

		public static IReadOnlySet<Position> ProcessMovement(InstructionRecord instruction, Position headPosition, Position tailPosition)
		{
			HashSet<Position> positions = new HashSet<Position>();

			for (int i = 0; i < instruction.times; i++)
			{
				// Move head.
				if (instruction.direction is InstructionDirectionEnum.up)
					headPosition.y++;

				if (instruction.direction is InstructionDirectionEnum.down)
					headPosition.y--;

				if (instruction.direction is InstructionDirectionEnum.right)
					headPosition.x++;

				if (instruction.direction is InstructionDirectionEnum.left)
					headPosition.x--;

				// Move tail.
				var xDifference = headPosition.x - tailPosition.x;
				var yDifference = headPosition.y - tailPosition.y;
				var sumDifference = Math.Abs(xDifference) + Math.Abs(yDifference);

				var cartessianDistance = Math.Sqrt(Math.Pow(headPosition.x - tailPosition.x, 2) + Math.Pow(headPosition.y - tailPosition.y, 2));

				if (cartessianDistance < 2)
					continue;

				// Make movements.
				int movX = (xDifference / 2);
				int movY = (yDifference / 2);

				tailPosition.x += movX;
				tailPosition.y += movY;

				if (sumDifference >= 3)
				{
                    if (xDifference is > 1 or < -1)
                    {
                        tailPosition.y += yDifference;
                    }
                    if (yDifference is > 1 or < -1)
                    {
                        tailPosition.x += xDifference;
                    }
                }

				MoveTail(headPosition, tailPosition);

				positions.Add(new Position { x = tailPosition.x, y = tailPosition.y });
			}

			return positions;
		}

		private static void MoveTail(Position headPosition, Position tailPosition)
		{
            // Move tail.
            var xDifference = headPosition.x - tailPosition.x;
            var yDifference = headPosition.y - tailPosition.y;
            var sumDifference = Math.Abs(xDifference) + Math.Abs(yDifference);

            var cartessianDistance = Math.Sqrt(Math.Pow(headPosition.x - tailPosition.x, 2) + Math.Pow(headPosition.y - tailPosition.y, 2));

            if (cartessianDistance < 2)
                return;

            // Make movements.
            int movX = (xDifference / 2);
            int movY = (yDifference / 2);

            tailPosition.x += movX;
            tailPosition.y += movY;

            if (sumDifference >= 3)
            {
                if (xDifference is > 1 or < -1)
                {
                    tailPosition.y += yDifference;
                }
                if (yDifference is > 1 or < -1)
                {
                    tailPosition.x += xDifference;
                }
            }
        }

		public enum InstructionDirectionEnum
		{
			invalid = 0,
			up,
			down,
			right,
			left
		}

		public class Position{ public int x; public int y;
            public override string ToString()
            {
                return $"x: {this.x} y: {y}.";
            }
        }

		public record InstructionRecord(InstructionDirectionEnum direction, int times)
		{
            public override string ToString()
            {
                return $"direction: {direction} times: {times}.";
            }
        }

        public class PositionComparer : IEqualityComparer<Position>
        {
			public bool Equals(Position? x, Position? y)
				=> x?.x == y?.x && x?.y == y?.y;

			public int GetHashCode([DisallowNull] Position obj)
			{
				return HashCode.Combine<int, int>(obj.x, obj.y);
			}
        }
    }
}

