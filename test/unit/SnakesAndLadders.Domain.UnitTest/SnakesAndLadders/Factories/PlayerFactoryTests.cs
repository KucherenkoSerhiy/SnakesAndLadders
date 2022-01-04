using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadders.Domain.SnakesAndLadders.Factories.Impl;
using SnakesAndLadders.Domain.SnakesAndLadders.Models;

namespace SnakesAndLadders.Domain.UnitTest.SnakesAndLadders.Factories
{
    [TestClass]
    public class PlayerFactoryTests
    {
        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void Build_InvalidNumberOfPlayers_ThrowsArgumentException(int numberOfPlayers)
        {
            var sut = new PlayerFactory();
            Assert.ThrowsException<ArgumentException>(() => sut.Build(numberOfPlayers));
        }
        
        [TestMethod]
        public void Build_OnePlayer_Ok()
        {
            var expectedPlayers = new List<PlayerToken>
            {
                new PlayerToken
                {
                    Name = "Player 1",
                    Position = 1,
                }
            };
            var sut = new PlayerFactory();
            var players = sut.Build(1);
            players.Should().BeEquivalentTo(expectedPlayers);
        }
        
        [TestMethod]
        public void Build_TwoPlayers_Ok()
        {
            var expectedPlayers = new List<PlayerToken>
            {
                new()
                {
                    Name = "Player 1",
                    Position = 1
                },
                new()
                {
                    Name = "Player 2",
                    Position = 1
                }
            };
            var sut = new PlayerFactory();
            var players = sut.Build(2);
            players.Should().BeEquivalentTo(expectedPlayers);
        }
    }
}