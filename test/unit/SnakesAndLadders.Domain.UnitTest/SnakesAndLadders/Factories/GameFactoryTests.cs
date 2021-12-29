using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SnakesAndLadders.Domain.SnakesAndLadders.Factories;
using SnakesAndLadders.Domain.SnakesAndLadders.Factories.Impl;
using SnakesAndLadders.Domain.SnakesAndLadders.Models;
using SnakesAndLadders.Domain.SnakesAndLadders.Models.Board;

namespace SnakesAndLadders.Domain.UnitTest.SnakesAndLadders.Factories
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class GameFactoryTests
    {
        [Test]
        public void Build_ValidCase_Ok()
        {
            var playerTokens = new List<PlayerToken>();
            var numberOfPlayers = 1;
            var board = new Board();
            var expectedGameInfo = new GameInfo
            {
                IsStarted = true,
                IsFinished = false,
                ActivePlayer = 1,
                Winner = 0
            };
            
            var sut = this.GetSut(out var playerFactoryMock, out var boardFactoryMock);
            playerFactoryMock.Setup(x => x.Build(numberOfPlayers)).Returns(playerTokens);
            boardFactoryMock.Setup(x => x.Build()).Returns(board);

            var game = sut.Build(numberOfPlayers);

            game.Info.Should().BeEquivalentTo(expectedGameInfo);
            game.Board.Should().BeSameAs(board);
            game.Players.Should().BeSameAs(playerTokens);
            playerFactoryMock.Verify(x => x.Build(numberOfPlayers), Times.Once);
            boardFactoryMock.Verify(x => x.Build(), Times.Once);
        }

        private GameFactory GetSut(
            out Mock<IPlayerFactory> playerFactoryMock,
            out Mock<IBoardFactory> boardFactoryMock)
        {
            playerFactoryMock = new Mock<IPlayerFactory>(MockBehavior.Strict);
            boardFactoryMock = new Mock<IBoardFactory>(MockBehavior.Strict);

            var sut = new GameFactory(playerFactoryMock.Object, boardFactoryMock.Object);
            return sut;
        }
    }
}