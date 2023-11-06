using System;
namespace AdventOfCode2022.Days.Helpers
{
	public static class Day10Helper
	{
		public static Instruction[] GetInstructions(string[] inputLines)
		{
			var instructions = inputLines.Select(x =>
			{
				var trimmedLine = x.Trim();

				var instruction = trimmedLine.StartsWith("noop") switch
				{
					true => new Instruction
					{
						CyclesLeft = 1,
						Operator = Operator.Noop
					},
					false => new Instruction
					{
						CyclesLeft = 2,
						Operator = Operator.AddX,
						Value = int.Parse(trimmedLine.Split(" ").ElementAt(1))
					}
				};

				return instruction;
			});

			return instructions.ToArray();
		}
	}

	public class Instruction
	{
		public int CyclesLeft { get; set; }

		public Operator Operator { get; set; }

		public int Value { get; set; }
	}

	public enum Operator
	{
		Undefined,
		AddX,
		Noop
	}
}

