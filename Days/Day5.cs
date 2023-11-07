using AdventOfCode2022.Days.Helpers;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Days
{
    internal class Day5 : BaseDay
    {
        public List<Stack<char>> StackList { get; set; }
        public List<Queue<char>> QueueList { get; set; }

        public Day5() : base(nameof(Day5))
        {
            StackList = new()
            {
                new( new[] { 'Q', 'W', 'P', 'S', 'Z', 'R', 'H', 'D' } ),
                new( new[] { 'V', 'B', 'R', 'W', 'Q', 'H', 'F' } ),
                new( new[] { 'C', 'V', 'S', 'H' } ),
                new( new[] { 'H', 'F', 'G', } ),
                new( new[] { 'P', 'G', 'J', 'B', 'Z', } ),
                new( new[] { 'Q', 'T', 'J', 'H', 'W', 'F', 'L' } ),
                new( new[] { 'Z', 'T', 'W', 'D', 'L', 'V', 'J', 'N' } ),
                new( new[] { 'D', 'T', 'Z', 'C', 'J', 'G', 'H', 'F' } ),
                new( new[] { 'W', 'P', 'V', 'M', 'B', 'H', } ),
            };

            QueueList = new();
        }

        public override string Solve1()
        {
            var regex = new Regex("\\d+");

            var localList = new List<Stack<char>>(StackList);

            var instructions = InputLines.SkipWhile(x => !x.StartsWith("move"));

            foreach (var instruction in instructions)
            {
                var tokens = regex.Matches(instruction);

                var movements = int.Parse(tokens[0].Value);
                var fromColumn = int.Parse(tokens[1].Value);
                var toColumn = int.Parse(tokens[2].Value);

                for (int i = 0; i < movements; i++)
                {
                    Day5Helper.MoveItem(localList, fromColumn, toColumn);
                }
            }

            var result = new string(localList.Select(x => x.Pop()).ToArray());

            return result;
        }

        public override string Solve2()
        {
            var regex = new Regex("\\d+");

            var localList = new List<Stack<char>>(StackList);

            var instructions = InputLines.SkipWhile(x => !x.StartsWith("move"));

            foreach (var instruction in instructions)
            {
                var tokens = regex.Matches(instruction);

                var movements = int.Parse(tokens[0].Value);
                var fromColumn = int.Parse(tokens[1].Value);
                var toColumn = int.Parse(tokens[2].Value);


                Enumerable.Range(0, movements)
                    .Select(x => localList[fromColumn - 1].Pop())
                    .Reverse()
                    .ToList()
                    .ForEach(x => localList[toColumn - 1].Push(x));
            }


            var result = new string(localList.Select(x => x.Pop()).ToArray());

            return result;
        }
    }
}
