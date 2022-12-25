using AdventOfCode2022.Days.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    internal class Day3 : BaseDay
    {
        public Day3() : base(nameof(Day3))
        {
            
        }

        public override string Solve1()
        {
            var result = InputLines.Select(x =>
            {
                var half = x.Length / 2;
                var firstSet = new HashSet<char>(x.Take(half).ToArray());
                var secondSet = new HashSet<char>(x.TakeLast(half).ToArray());

                var intersection = firstSet.Intersect(secondSet).First();

                return Day3Helper.GetPriorityValue(intersection);
            }).Sum()
            .ToString();

            return result;
        }

        public override string Solve2()
        {
            var numberOfArrays = InputLines.Length / 3;
            List<string[]> arraysList = new();

            for (int i = 0; i < InputLines.Length; i += 3)
            {
                var array = InputLines.Skip(i)
                    .Take(3)
                    .ToArray();
                arraysList.Add(array);
            }

            var badgeSum = arraysList.Select(x =>
            {
                var hashSets = x.Select(s => new HashSet<char>(s.ToCharArray()));

                var badge = hashSets.Aggregate((a, b) => new HashSet<char>(a.Intersect(b))).First();

                var badgePriority = Day3Helper.GetPriorityValue(badge);

                return badgePriority;
            }).Sum();

            return badgeSum.ToString();
        }
    }
}
