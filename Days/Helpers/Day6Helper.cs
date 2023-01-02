using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days.Helpers
{
    public static class Day6Helper
    {
        public static int GetIndexOf(string sCase, int count = 4)
        {
            for (int i = 0; i < sCase.Length; i++)
            {
                var set = new HashSet<char>(sCase.Skip(i).Take(count));

                if (set.Count == count) return i + count;
            }

            return -1;
        }
    }
}
