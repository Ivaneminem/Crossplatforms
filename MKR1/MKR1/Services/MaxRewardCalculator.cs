using MKR1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1.Services
{
    public class MaxRewardCalculator
    {
        public int CalculateMaxReward(List<Order> orders)
        {
            // Сортуємо замовлення за винагородою у порядку спадання
            var sortedOrders = orders.OrderByDescending(order => order.Ci).ToList();

            // Масив для відмітки виконаних днів
            bool[] days = new bool[1001];
            int totalReward = 0;

            // Проходимо через кожне замовлення
            foreach (var order in sortedOrders)
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

            return totalReward;
        }
    }
}
