using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Читання даних із файлу INPUT.TXT
        var lines = File.ReadAllLines("INPUT.TXT");
        int n = int.Parse(lines[0]);
        var orders = new (int Ti, int Ci)[n];

        for (int i = 0; i < n; i++)
        {
            var parts = lines[i + 1].Split();
            int Ti = int.Parse(parts[0]);
            int Ci = int.Parse(parts[1]);
            orders[i] = (Ti, Ci);
        }

        // Сортуємо замовлення за винагородою у порядку спадання
        orders = orders.OrderByDescending(order => order.Ci).ToArray();

        // Масив для відмітки виконаних днів
        bool[] days = new bool[1001];
        int totalReward = 0;

        // Проходимо через кожне замовлення
        foreach (var order in orders)
        {
            // Знаходимо найближчий доступний день для виконання
            for (int day = order.Ti; day > 0; day--)
            {
                if (!days[day])
                {
                    days[day] = true;
                    totalReward += order.Ci;
                    break;
                }
            }
        }

        // Записуємо результат у файл OUTPUT.TXT
        File.WriteAllText("OUTPUT.TXT", totalReward.ToString());
    }
}
