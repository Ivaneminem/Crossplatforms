using MKR1.Models;
using MKR1.Services;
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Читання даних із файлу INPUT.TXT
        var orders = LoadOrders("INPUT.TXT");

        // Ініціалізація калькулятора винагороди
        var calculator = new MaxRewardCalculator();

        // Обчислення максимальної винагороди
        int totalReward = calculator.CalculateMaxReward(orders);

        // Запис результату у файл OUTPUT.TXT
        File.WriteAllText("OUTPUT.TXT", totalReward.ToString());

        Console.WriteLine("Максимальна винагорода записана у OUTPUT.TXT.");
    }

    private static List<Order> LoadOrders(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        int n = int.Parse(lines[0]);
        var orders = new List<Order>();

        for (int i = 0; i < n; i++)
        {
            var parts = lines[i + 1].Split();
            int Ti = int.Parse(parts[0]);
            int Ci = int.Parse(parts[1]);
            orders.Add(new Order(Ti, Ci));
        }

        return orders;
    }
}
