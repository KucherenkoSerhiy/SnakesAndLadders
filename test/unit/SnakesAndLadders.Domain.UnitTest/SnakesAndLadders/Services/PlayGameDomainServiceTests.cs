using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SnakesAndLadders.Domain.SnakesAndLadders.Containers;
using SnakesAndLadders.Domain.SnakesAndLadders.Factories;
using SnakesAndLadders.Domain.SnakesAndLadders.Models;
using SnakesAndLadders.Domain.SnakesAndLadders.Models.Board;
using SnakesAndLadders.Domain.SnakesAndLadders.Services;
using SnakesAndLadders.Domain.SnakesAndLadders.Services.Impl;

namespace SnakesAndLadders.Domain.UnitTest.SnakesAndLadders.Services
{
    [TestClass]
    public class PlayGameDomainServiceTests
    {
        [TestMethod]
        public void Build_ValidParameters_Ok()
        {
            var numberOfPlayers = 1;
            var game = new Game();

            var sut = this.GetSut(out var gameFactoryMock, out var gameContainerMock, out _);
            gameFactoryMock.Setup(x => x.Build(numberOfPlayers)).Returns(game);
            gameContainerMock.SetupSet(x => x.Game = game);

            sut.Build(numberOfPlayers);

            gameFactoryMock.Verify(x => x.Build(numberOfPlayers), Times.Once);
            gameContainerMock.VerifySet(x => x.Game = game, Times.Once);
        }

        [TestMethod]
        public void MakeMove_GameAlreadyFinished_Throws()
        {
            var game = new Game {Info = new GameInfo {IsFinished = true}};

            var sut = this.GetSut(out _, out var gameContainerMock, out _);
            gameContainerMock.SetupGet(x => x.Game).Returns(game);

            Assert.ThrowsException<ApplicationException>(() => sut.MakeMove());

            gameContainerMock.VerifyGet(x => x.Game, Times.Once);
        }

        [TestMethod]
        public void MakeMove_DieHasMoreValueThanPlayerCanMove_SkipsPlayersTurn()
        {
            var activePlayerNumber = 1;
            var playerPosition = 97;
            var dieRoll = 4;
            var expectedPlayerPosition = playerPosition;
            var playerToken = new PlayerToken {Position = playerPosition};
            var cells = Enumerable.Range(1, 100).ToDictionary(number => number, number => (Cell) new EmptyCell());
            var game = CreateGame(activePlayerNumber, playerToken, cells);

            var sut = this.GetSut(out _, out var gameContainerMock, out var dieMock);
            gameContainerMock.SetupGet(x => x.Game).Returns(game);
            dieMock.Setup(x => x.Roll()).Returns(dieRoll);

            sut.MakeMove();

            playerToken.Position.Should().Be(expectedPlayerPosition);
            game.Info.Winner.Should().BeNullOrEmpty();
            game.Info.IsFinished.Should().BeFalse();
            gameContainerMock.VerifyGet(x => x.Game, Times.Once);
            dieMock.Verify(x => x.Roll(), Times.Once);
        }

        [TestMethod]
        public void MakeMove_WinningMove_MovesPlayerAndFinishesTheGame()
        {
            var activePlayerNumber = 1;
            var playerPosition = 97;
            var dieRoll = 3;
            var expectedWinnerPlayerNumber = 1;
            var expectedPlayerPosition = playerPosition + dieRoll;
            var playerName = $"Player {expectedWinnerPlayerNumber}";
            var playerToken = new PlayerToken {Position = playerPosition, Name = playerName};
            var cells = Enumerable.Range(1, 100).ToDictionary(number => number, number => (Cell) new EmptyCell());
            var game = CreateGame(activePlayerNumber, playerToken, cells);

            var sut = this.GetSut(out _, out var gameContainerMock, out var dieMock);
            gameContainerMock.SetupGet(x => x.Game).Returns(game);
            dieMock.Setup(x => x.Roll()).Returns(dieRoll);

            sut.MakeMove();

            playerToken.Position.Should().Be(expectedPlayerPosition);
            game.Info.Winner.Should().Be(playerName);
            game.Info.IsFinished.Should().BeTrue();
            gameContainerMock.VerifyGet(x => x.Game, Times.Once);
            dieMock.Verify(x => x.Roll(), Times.Once);
        }

        [TestMethod]
        public void MakeMove_RegularMove_MovesPlayer()
        {
            var activePlayerNumber = 1;
            var playerPosition = 5;
            var dieRoll = 3;
            var expectedPlayerPosition = playerPosition + dieRoll;
            var playerToken = new PlayerToken {Position = playerPosition};
            var cells = Enumerable.Range(1, 100).ToDictionary(number => number, number => (Cell) new EmptyCell());
            var game = CreateGame(activePlayerNumber, playerToken, cells);

            var sut = this.GetSut(out _, out var gameContainerMock, out var dieMock);
            gameContainerMock.SetupGet(x => x.Game).Returns(game);
            dieMock.Setup(x => x.Roll()).Returns(dieRoll);

            sut.MakeMove();

            playerToken.Position.Should().Be(expectedPlayerPosition);
            game.Info.IsFinished.Should().BeFalse();
            gameContainerMock.VerifyGet(x => x.Game, Times.Once);
            dieMock.Verify(x => x.Roll(), Times.Once);
        }

        private PlayGameDomainService GetSut(
            out Mock<IGameFactory> gameFactoryMock,
            out Mock<IGameContainer> gameContainerMock,
            out Mock<IDie> dieMock)
        {
            gameFactoryMock = new Mock<IGameFactory>(MockBehavior.Strict);
            gameContainerMock = new Mock<IGameContainer>(MockBehavior.Strict);
            dieMock = new Mock<IDie>(MockBehavior.Strict);

            var sut = new PlayGameDomainService(gameFactoryMock.Object,
                gameContainerMock.Object, dieMock.Object);

            return sut;
        }

        private static Game CreateGame(int activePlayerNumber, PlayerToken playerToken, Dictionary<int, Cell> cells)
        {
            return new Game
            {
                Info = new GameInfo
                {
                    ActivePlayer = activePlayerNumber
                },
                Players = new List<PlayerToken>
                {
                    playerToken
                },
                Board = new Board
                {
                    Cells = cells
                }
            };
        }
    }
}