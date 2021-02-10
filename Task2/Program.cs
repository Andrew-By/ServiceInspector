using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static int[] input;

        static void Main(string[] args)
        {
            input = new int[] { 3, 1, 8, 5, 4 };
            int target = 2;
            foreach (int i in input)
            {
                var result = new HashSet<int> { i };
                if (CanSubtract(ref result, target - i))
                {
                    Console.WriteLine("Можно (" + string.Join("+", result) + ")");
                    return;
                }
            }
            Console.WriteLine("Нельзя");
        }

        static bool CanSubtract(ref HashSet<int> result, int current)
        {
            foreach (int i in input)
            {
                if (!result.Contains(i))
                {
                    if (i <= current)
                    {
                        var branchResult = new HashSet<int>(result);
                        branchResult.Add(i);
                        if (i < current)
                        {
                            if (!CanSubtract(ref branchResult, current - i))
                                continue;
                        }
                        result = branchResult;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
