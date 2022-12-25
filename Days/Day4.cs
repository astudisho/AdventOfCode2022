using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    internal class Day4 : BaseDay
    {
        public Day4() : base(nameof(Day4))
        {

        }

        public override string Solve1()
        {
            var count = InputLines.Select(x =>
            {
                var tuples = x.Split(",")
                .Select(l =>
                {
                    var lines = l.Split("-");
                    return (lines[0], lines[1]);
                }).ToArray();

                var count1 = int.Parse(tuples[0].Item2) - int.Parse(tuples[0].Item1) + 1;
                var first = new HashSet<int>(Enumerable.Range(int.Parse(tuples[0].Item1), count1));

                var count2 = int.Parse(tuples[1].Item2) - int.Parse(tuples[1].Item1) + 1;
                var second = new HashSet<int>(Enumerable.Range(int.Parse(tuples[1].Item1), count2));

                return first.IsSubsetOf(second) || second.IsSubsetOf(first);

            }).Count(x => x);

            return count.ToString();
        }

        public override string Solve2()
        {
            var count = InputLines.Select(x =>
            {
                var tuples = x.Split(",")
                .Select(l =>
                {
                    var lines = l.Split("-");
                    return (lines[0], lines[1]);
                }).ToArray();

                var count1 = int.Parse(tuples[0].Item2) - int.Parse(tuples[0].Item1) + 1;
                var first = new HashSet<int>(Enumerable.Range(int.Parse(tuples[0].Item1), count1));

                var count2 = int.Parse(tuples[1].Item2) - int.Parse(tuples[1].Item1) + 1;
                var second = new HashSet<int>(Enumerable.Range(int.Parse(tuples[1].Item1), count2));

                return first.Intersect(second).Any();

            }).Count(x => x);

            return count.ToString();
        }
    }
}
