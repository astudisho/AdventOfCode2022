using System;
using System.Runtime.CompilerServices;
namespace AdventOfCode2022.Days.Helpers
{
	public static class Day12Helper
	{
		public static List<List<Node>> GetMatrix(string[] lines)
		{
			// var nodes = lines.Select(x => x.Select(y => new Node()
			// {
			// 	Value = y - 'a',
			// 	Character = y,
			// }).ToArray()
			// ).ToArray();

			var rows = lines.Length;
			var columns = lines.First().Trim().Length;
			var matrix = new List<List<Node>>(rows);

			for (int i = 0; i < lines.Count(); i++)
			{
				matrix.Add( new List<Node>(columns));
				for (int j = 0; j < lines[i].Trim().Length; j++)
				{
					matrix[i].Add(new Node 
					{
						Value = lines[i][j] - 'a',
						Character = lines[i][j],
						Position = (j, i),
					});
				}
			}

			return matrix;
		}

		public static List<Node> GetNodesToVisit((int x, int y) position, List<List<Node>> matrix)
        {
            var toVisitNodes = new List<Node>(4);
            var currentNode = matrix[position.y][position.x];

            // Left.
            if(position.x - 1 is > 0)
            {
                AddNodeIfNotVisited(position.x - 1, position.y, toVisitNodes, currentNode);
            }
            // Right.
            if(position.x + 1 < matrix.First().Count)
            {
                AddNodeIfNotVisited(position.x + 1, position.y, toVisitNodes, currentNode);
            }
            // Up.
            if(position.y - 1 is > 0)
            {
                AddNodeIfNotVisited(position.x, position.y - 1, toVisitNodes, currentNode);
            }
            // Down.
            if(position.y + 1 < matrix.Count)
            {
                AddNodeIfNotVisited(position.x, position.y + 1, toVisitNodes, currentNode);
            }

            return toVisitNodes;

            void AddNodeIfNotVisited(int x, int y, List<Node> toVisitNodes, Node currentNode)
            {
                var node = matrix[y][x];

                if(node.Value - currentNode.Value is <= 1)
                    toVisitNodes.Add(node);
            }
        }
	}

	public class Node
	{
		private int _value;
		public uint Weight { get;  set; } = int.MaxValue;

		public int Value { get => _value; set { _value = value is < 0 ? 0: value; } }

		public char Character { get; set; }

		public (int y, int x) Position { get; set; }

        public override string ToString()
        {
            return $"w: {Weight} v: {Value} c: {Character} p: {Position.x},{Position.y}";
        }
    }
}

