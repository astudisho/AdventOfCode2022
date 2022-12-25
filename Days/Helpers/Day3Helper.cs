using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days.Helpers
{
    public static class Day3Helper
    {
        public static int GetPriorityValue(char value)
        {

            if (value >= 'A' && value <= 'Z')
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
