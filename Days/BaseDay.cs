using AdventOfCode2022.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    internal abstract class BaseDay
    {
        public string DayName { get; init; }
        public string[] InputLines { get; init; }

        public BaseDay(string dayName)
        {
            DayName = dayName;

            var path = $"Inputs\\{dayName}.txt";
            InputLines = InputReader.GetInput(path)
                .GetAwaiter()
                .GetResult();
        }

        public abstract string Solve1();
        public abstract string Solve2();
    }
}
