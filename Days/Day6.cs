using AdventOfCode2022.Days.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    public class Day6 : BaseDay
    {
        public Day6() : base(nameof(Day6))
        {

        }
        public override string Solve1()
        {
            var result = Day6Helper.GetIndexOf(InputLines.First());

            return result.ToString();
        }

        public override string Solve2()
        {
            var result = Day6Helper.GetIndexOf(InputLines.First(), 14);

            return result.ToString();
        }
    }
}
