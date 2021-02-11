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
            var orders = new HashSet<int>(); // Справки, которые можно получить
            var officers = new Dictionary<int, int[]>(); // Зависимости между чиновниками
            bool hasLoop = false; // Флаг наличия циклической зависимости
            officers.Add(1, new[] { 2 });
            officers.Add(2, new[] { 3, 4 });
            int current = 1;
            while (orders.Count < n)
            {
                if (!orders.Contains(current))
                {
                    bool hasAll = true;
                    if (officers.ContainsKey(current))
                    {
                        foreach (var depends in officers[current])
                        {
                            if (!orders.Contains(depends))
                            {
                                hasAll = false;
                                break;
                            }
                        }
                    }

                    if (hasAll)
                    {
                        hasLoop = false;
                        orders.Add(current);
                    }

                }
                if (current < n)
                    current++;
                else
                {
                    if (hasLoop)
                    {
                        Console.WriteLine("В зависимостях обнаружен цикл!");
                        return;
                    }
                    hasLoop = true;
                    current = 1;
                }
            }
            Console.WriteLine(string.Join(" ", orders));
        }
    }
}
