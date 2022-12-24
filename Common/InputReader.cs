using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Common
{
    internal class InputReader
    {
        public static async Task<string[]>  GetInput(string path)
        {
            var text = await File.ReadAllLinesAsync(path);

            return text;
        }
    }
}
