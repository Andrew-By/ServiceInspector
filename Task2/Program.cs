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
            TargetAsSum(10);
            TargetAsSum(2);
        }

        static void TargetAsSum(int target)
        {
            Console.Write($"Число {target} ");
            foreach (int i in input)
            {
                var result = new HashSet<int> { i };
                if (CanSubtract(ref result, target - i))
                {
                    Console.WriteLine("можно представить в виде суммы (" + string.Join("+", result) + ")");
                    return;
                }
            }
            Console.WriteLine("нельзя представить в виде суммы");
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
