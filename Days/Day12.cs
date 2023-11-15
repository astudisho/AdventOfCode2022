using System;
using AdventOfCode2022.Days.Helpers;

namespace AdventOfCode2022.Days
{
    public class Day12 : BaseDay
    {
        public Day12() : base(nameof(Day12), "Inputs/Test")
        {
        }

        public override string Solve1()
        {
            var matrix = Day12Helper.GetMatrix(InputLines);

            var start = matrix.SelectMany(x => x).First(x => x.Character == 'S');
            var exit = matrix.SelectMany(x => x).First(x => x.Character == 'E');

            var notVisited = new List<Node>(matrix.SelectMany(x => x).Where(x => x.Character is not 'S'));

            var currentNode = start;
            start.Weight = 0;

            while(notVisited.Any())
            {
                var toVisitNodes = Day12Helper.GetNodesToVisit(currentNode.Position, matrix);
                notVisited.Remove(currentNode);

                foreach (var node in toVisitNodes)
                {
                    if((currentNode.Weight + 1) < node.Weight)
                        node.Weight = currentNode.Weight + 1;
                }

                var orderedNodes = notVisited.OrderBy(x => x.Weight).ToList();

                if(orderedNodes.Any())
                    currentNode = orderedNodes.First();
            }

            return exit.Weight.ToString();
        }

        

        public override string Solve2()
        {
            throw new NotImplementedException();
        }
    }
}

