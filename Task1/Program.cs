using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4; // Количество чиновников
            var references = new HashSet<int>(); // Справки, которые можно получить
            var officers = new Dictionary<int, int[]>(); // Зависимости между чиновниками
            officers.Add(1, new[] { 2 });
            officers.Add(2, new[] { 3, 4 });
            int current = 1;
            while (references.Count < n)
            {
                if (!references.Contains(current))
                {
                    bool hasAll = true;
                    if (officers.ContainsKey(current))
                    {
                        foreach (var depends in officers[current])
                        {
                            if (!references.Contains(depends))
                            {
                                hasAll = false;
                                break;
                            }
                        }
                    }

                    if (hasAll)
                        references.Add(current);

                }
                if (current < n)
                    current++;
                else
                    current = 1;
            }
            Console.WriteLine(string.Join(" ", references));
        }
    }
}
