using Xunit;
using MKR1; // Простір імен основного проєкту
using System.Collections.Generic;
using MKR1.Models;
using MKR1.Services;

namespace MKR1.Tests
{
    public class MaxRewardCalculatorTests
    {
        [Fact]
        public void Test_SingleOrder_ReturnsOrderReward()
        {
            // Arrange
            var orders = new List<Order> { new Order(1, 10) };
            var calculator = new MaxRewardCalculator();

            // Act
            int result = calculator.CalculateMaxReward(orders);

            // Assert
            Assert.Equal(10, result);
        }

        [Fact]
        public void Test_MultipleOrders_ReturnsMaxReward()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order(1, 10),
                new Order(2, 12)
            };
            var calculator = new MaxRewardCalculator();

            // Act
            int result = calculator.CalculateMaxReward(orders);

            // Assert
            Assert.Equal(22, result);
        }

        [Fact]
        public void Test_OrdersWithSameDeadline_ReturnsBestRewardCombination()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order(1, 10),
                new Order(1, 20),
                new Order(3, 24)
            };
            var calculator = new MaxRewardCalculator();

            // Act
            int result = calculator.CalculateMaxReward(orders);

            // Assert
            Assert.Equal(44, result);
        }

        [Fact]
        public void Test_NoOrders_ReturnsZero()
        {
            // Arrange
            var orders = new List<Order>();
            var calculator = new MaxRewardCalculator();

            // Act
            int result = calculator.CalculateMaxReward(orders);

            // Assert
            Assert.Equal(0, result);
        }
    }
}