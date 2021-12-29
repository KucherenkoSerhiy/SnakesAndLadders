using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using SnakesAndLadders.Domain.SnakesAndLadders.Factories.Impl;
using SnakesAndLadders.Domain.SnakesAndLadders.Models;

namespace SnakesAndLadders.Domain.UnitTest.SnakesAndLadders.Factories
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class PlayerFactoryTests
    {
        [TestCase(-1)]
        [TestCase(0)]
        public void Build_InvalidNumberOfPlayers_ThrowsArgumentException(int numberOfPlayers)
        {
            var sut = new PlayerFactory();
            Assert.Throws<ArgumentException>(() => sut.Build(numberOfPlayers));
        }
        
        [Test]
        public void Build_OnePlayer_Ok()
        {
            var expectedPlayers = new List<PlayerToken>
            {
                new PlayerToken
                {
                    Name = "Player 1",
                    Position = 1,
                    IsTheirTurn = true
                }
            };
            var sut = new PlayerFactory();
            var players = sut.Build(1);
            players.Should().BeEquivalentTo(expectedPlayers);
        }
        
        [Test]
        public void Build_TwoPlayers_Ok()
        {
            var expectedPlayers = new List<PlayerToken>
            {
                new()
                {
                    Name = "Player 1",
                    Position = 1,
                    IsTheirTurn = true
                },
                new()
                {
                    Name = "Player 2",
                    Position = 1,
                    IsTheirTurn = false
                }
            };
            var sut = new PlayerFactory();
            var players = sut.Build(2);
            players.Should().BeEquivalentTo(expectedPlayers);
        }
    }
}