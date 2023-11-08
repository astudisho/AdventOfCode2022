using System;
using AdventOfCode2022.Days.Helpers;

namespace AdventOfCode2022.Days
{
	public class Day11 : BaseDay
	{
        public Day11() : base(nameof(Day11), "Inputs")
        {
        }

        public override string Solve1()
        {
            var monkeys = Day11Helper.GetMonkeys();
            var maxRounds = 20;

            for (int i = 0; i < maxRounds; i++)
            {
                foreach (var monkey in monkeys)
                {
                    solve1Action(monkey, monkeys);
                }
            }

            var mostActiveMonkeys = monkeys
                .OrderByDescending(x => x.TimesInspected)
                .Take(2)
                .ToArray();
            var result = mostActiveMonkeys[0].TimesInspected * mostActiveMonkeys[1].TimesInspected;
            return result.ToString();
        }

        Action<Monkey, Monkey[]> solve1Action = (Monkey monkey, Monkey[] monkeys) =>
        {
            while(monkey.ItemsQueue.Any())
            {
                var item = monkey.ItemsQueue.Dequeue();

                var newItem = monkey.Operation(item);

                newItem /= 3;

                var testResult = monkey.Test(newItem);

                if (testResult)
                {
                    monkeys[monkey.ThrowTo.ifTrue].ItemsQueue.Enqueue(newItem);
                }
                else
                {
                    monkeys[monkey.ThrowTo.ifFalse].ItemsQueue.Enqueue(newItem);
                }

                monkey.TimesInspected++;
            }
        };

        Action<Monkey, Monkey[]> solve2Action = (Monkey monkey, Monkey[] monkeys) =>
        {
            while (monkey.ItemsQueue.Any())
            {
                var item = monkey.ItemsQueue.Dequeue();

                var newItem = monkey.Operation(item);

                newItem %= 96577;

                var testResult = monkey.Test(newItem);

                if (testResult)
                {
                    monkeys[monkey.ThrowTo.ifTrue].ItemsQueue.Enqueue(newItem);
                }
                else
                {
                    monkeys[monkey.ThrowTo.ifFalse].ItemsQueue.Enqueue(newItem);
                }

                monkey.TimesInspected++;
            }
        };

        public override string Solve2()
        {
            var monkeys = Day11Helper.GetMonkeysTest();
            var maxRounds = 1000;

            for (int i = 0; i < maxRounds; i++)
            {
                foreach (var monkey in monkeys)
                {
                    solve2Action(monkey, monkeys);
                }
            }

            var mostActiveMonkeys = monkeys
                .OrderByDescending(x => x.TimesInspected)
                .Take(2)
                .ToArray();
            long result = mostActiveMonkeys[0].TimesInspected * mostActiveMonkeys[1].TimesInspected;
            return result.ToString();
        }
    }
}

