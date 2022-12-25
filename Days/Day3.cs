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

                return GetPriorityValue(intersection);
            }).Sum()
            .ToString();

            return result;
        }

        public override string Solve2()
        {
            throw new NotImplementedException();
        }

        int GetPriorityValue(char value)
        {

            if(value >= 'A' && value <= 'Z')
            {
                return value - 'A' + 27;
            }
            else
            {
                return value - 'a' + 1;
            }
        }
    }
}
