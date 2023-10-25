using AdventOfCode2022.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days
{
    public abstract class BaseDay
    {
        public string DayName { get; init; }
        public string[] InputLines { get; init; }

        public BaseDay(string dayName, string containerDirectory = "Inputs")
        {
            DayName = dayName;
            var dayNameFile = $"{dayName}.txt";

            var path = Path.Combine(containerDirectory, dayNameFile);

            InputLines = InputReader.GetInput(path)
                .GetAwaiter()
                .GetResult();
        }

        public abstract string Solve1();
        public abstract string Solve2();
    }
}
