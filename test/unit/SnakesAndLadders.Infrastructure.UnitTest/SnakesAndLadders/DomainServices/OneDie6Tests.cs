using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using SnakesAndLadders.Infrastructure.SnakesAndLadders.DomainServices;

namespace SnakesAndLadders.Infrastructure.UnitTest.SnakesAndLadders.DomainServices
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class OneDie6Tests
    {
        [Test]
        public void Roll_10000Times_ReturnsValuesBetween1And6()
        {
            var totalRolls = 10000;
            var sut = new OneDie6();
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
    }
}