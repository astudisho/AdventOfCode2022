using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Days.Helpers
{
    public static class Day5Helper
    {
        public static void MoveItem(List<Stack<char>> stackList, int fromColumn, int toColumn)
        {
            var item = stackList[fromColumn - 1].Pop();
            stackList[toColumn - 1].Push(item);
        }
    }
}
