using System;
using AdventOfCode2022.Common;

namespace AdventOfCode2022.Days
{
    public class Day8 : BaseDay
	{

        
		public Day8()
            : base(nameof(Day8), "Inputs/Test")
            //: base(nameof(Day8))

        {
            
		}

        public override string Solve1()
        {
            var result = string.Empty;

            var grid = InputLines.Select(line => line.Trim().Select(number => int.Parse( number.ToString()))
                .ToArray())
                    .ToArray();

            var xSize = grid[0].Count();
            var ySize = InputLines.Count();

            var visibleTrees = (ySize * 2) + (ySize * 2 - 4);

            for (int y = 1; y < ySize - 1; y++)
            {
                for (int x = 1; x < xSize - 1; x++)
                {
                    var isVisibleRow = IsVisible(x, grid[y]);
                    var column = TakeColumn(x, grid);
                    var isVisibleColumn = IsVisible(y, column);

                    if (isVisibleColumn || isVisibleRow)
                        visibleTrees++;
                }
            }

            return visibleTrees.ToString();


            bool IsVisible(int pos, int[] array)
            {
                // Check left.
                var leftArray = array.Take(pos).ToArray();
                var visibleFromLeft = leftArray
                    .All(x => array[pos] > x);

                // Check right.
                var rightArray = array.TakeLast(array.Count() - pos - 1).ToArray();
                var visibleFromRight = rightArray
                    .All(x => array[pos] > x);

                return visibleFromLeft || visibleFromRight;
            }
        }

        int[] TakeColumn(int posX, int[][] grid)
        {
            var reslt = grid.Select(x => x[posX]).ToArray();

            return reslt;
        }

        public override string Solve2()
        {
            var result = string.Empty;

            var grid = InputLines.Select(line => line.Trim().Select(number => int.Parse(number.ToString()))
                .ToArray())
                    .ToArray();

            var xSize = grid[0].Count();
            var ySize = InputLines.Count();

            var visibleTrees = (ySize * 2) + (ySize * 2 - 4);

            var maxView = int.MinValue;

            for (int y = 1; y < ySize - 1; y++)
            {
                for (int x = 1; x < xSize - 1; x++)
                {
                    var countRow = CountViewableTrees(x, grid[y]);

                    var column = TakeColumn(x, grid);
                    var countColumn = CountViewableTrees(y, column);

                    var totalView = countRow * countColumn;

                    if(totalView > maxView)
                    {
                        maxView = totalView;
                    }
                }
            }

            return maxView.ToString();

            int CountViewableTrees(int pos, int[] array)
            {
                // Check left.
                var leftArray = array.Take(pos)
                    .Reverse()
                    .ToArray();

                var leftView = leftArray.TakeWhile(x => x < array[pos]).Count();

                if (leftView == 0) leftView++;

                // Check right.
                var rightArray = array
                    .TakeLast(array.Count() - pos - 1)
                    .ToArray();

                var rightView = rightArray.TakeWhile(x => x < array[pos]).Count();
                if (rightView == 0) rightView++;

                return leftView * rightView;
            }
        }
    }
}