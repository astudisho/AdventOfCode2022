using System;
namespace AdventOfCode2022.Days.Helpers
{
	public static class Day11Helper
	{
		public static Monkey[] GetMonkeysTest() => new Monkey[]
		{
			new Monkey
			{
				ItemsQueue = new(new List<int> { 79, 98 } ),
				Operation = (old) => old * 19,
				Test = (n) => n % 23 == 0,
				ThrowTo = (2,3),
			},
			new()
			{
				ItemsQueue = new (new List<int>(){ 54, 65, 75, 74 }),
				Operation = (old) => old + 6,
				Test = (n) => n % 19 == 0,
				ThrowTo = (2,0),
			},
			new()
			{
				ItemsQueue = new (new List<int> { 79, 60, 97 }),
				Operation = (old) => old * old,
				Test = (n) => n % 13 == 0,
				ThrowTo = (1 ,3)
			},
			new()
			{
				ItemsQueue = new(new List<int> { 74 }),
				Operation = (old) => old + 3,
				Test = (n) => n % 17 is 0,
				ThrowTo = (0 , 1)
			}
		};

        public static Monkey[] GetMonkeys() => new Monkey[]
        {
            new Monkey
            {
                ItemsQueue = new(new List<int> { 74, 64, 74, 63, 53 } ),
                Operation = (old) => old * 7,
                Test = (n) => n % 5 == 0,
                ThrowTo = (1,6),
            },
            new()
            {
                ItemsQueue = new (new List<int>(){ 69, 99, 95, 62 }),
                Operation = (old) => old * old,
                Test = (n) => n % 17 == 0,
                ThrowTo = (2,5),
            },
            new()
            {
                ItemsQueue = new (new List<int> { 59, 81 }),
                Operation = (old) => old + 8,
                Test = (n) => n % 7 == 0,
                ThrowTo = (4 ,3)
            },
            new()
            {
                ItemsQueue = new(new List<int> { 50, 67, 63, 57, 63, 83, 97 }),
                Operation = (old) => old + 4,
                Test = (n) => n % 13 == 0,
                ThrowTo = (0 , 7)
            },
            new()
            {
                ItemsQueue = new (new List<int> { 61, 94, 85, 52, 81, 90, 94, 70 }),
                Operation = (old) => old + 3,
                Test = (n) => n % 19 == 0,
                ThrowTo = (7 ,3)
            },
            new()
            {
                ItemsQueue = new (new List<int> { 69 }),
                Operation = (old) => old + 5,
                Test = (n) => n % 3 == 0,
                ThrowTo = (4 ,2)
            },
            new()
            {
                ItemsQueue = new (new List<int> { 54, 55 ,58 }),
                Operation = (old) => old + 7,
                Test = (n) => n % 11 == 0,
                ThrowTo = (1 , 5)
            },
            new()
            {
                ItemsQueue = new (new List<int> { 79, 51, 83, 88, 93, 76 }),
                Operation = (old) => old * 3,
                Test = (n) => n % 2 == 0,
                ThrowTo = (0 ,6)
            },
        };
    }

	public class Monkey
	{
		public Queue<int> ItemsQueue { get; set; } = new();

		public Func<int, int>? Operation;

		public Func<int, bool>? Test;

		public (int ifTrue, int ifFalse) ThrowTo;

		public long TimesInspected { get; set; } = 0;
	}
}