using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnakesAndLadders.Infrastructure.SnakesAndLadders.DomainServices;

namespace SnakesAndLadders.Infrastructure.UnitTest.SnakesAndLadders.DomainServices
{
    [TestClass]
    public class OneDie6Tests
    {
        [TestMethod]
        public void Roll_10000Times_ReturnsValuesBetween1And6()
        {
            var totalRolls = 10000;
            var sut = GetSut(out _);
            var rollCounter = new Dictionary<int, int>();

            for (var i = 0; i < totalRolls; i++)
            {
                var roll = sut.Roll();
                if (!rollCounter.ContainsKey(roll))
                    rollCounter[roll] = 1;
                else
                    rollCounter[roll]++;
            }

            var validRolls = 0;
            for (var i = 1; i <= 6; i++)
                validRolls += rollCounter[i];
            validRolls.Should().Be(totalRolls);

            for (var i = 1; i <= 6; i++)
                rollCounter[i].Should().BeGreaterThan(0);
        }

        private static OneDie6 GetSut(out Mock<ILogger<OneDie6>> loggerMock)
        {
            loggerMock = new Mock<ILogger<OneDie6>>(MockBehavior.Loose);
            return new OneDie6(loggerMock.Object);
        }
    }
}