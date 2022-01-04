using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SnakesAndLadders.BehaviorTest.Mocks;
using SnakesAndLadders.Domain.SnakesAndLadders.Services;
using TechTalk.SpecFlow;

namespace SnakesAndLadders.BehaviorTest.Steps
{
    [Binding]
    [Scope(Feature = "Token Can Move Across The Board")]
    [Scope(Feature = "Player Can Win the Game")]
    public sealed class SnakesAndLaddersSteps
    {
        private readonly int _numberOfPlayers = 1;
        private int _player1Location = 1;
        private readonly ServiceCollection _serviceCollection;
        private IPlayGameDomainService _sut;
        private ServiceProvider _serviceProvider;

        public SnakesAndLaddersSteps()
        {
            _serviceCollection = IoCSetup.SetupIoCContainer();
        }

        [Given(@"the game is started")]
        public void GivenTheGameIsStarted()
        {
            _serviceProvider = _serviceCollection.BuildServiceProvider();
            _sut = _serviceProvider.GetService<IPlayGameDomainService>();
            _sut.Build(_numberOfPlayers);
        }

        [Given(@"the token is on square (.*)")]
        public void GivenTheTokenIsOnSquare(int squareNumber)
        {
            _serviceCollection.Replace(ServiceDescriptor.Scoped<IDie, DieMock>());
            _player1Location = squareNumber;
            _serviceProvider = _serviceCollection.BuildServiceProvider();
            _sut = _serviceProvider.GetService<IPlayGameDomainService>();
            _sut.Build(_numberOfPlayers);
            
            var game = _sut.GetGameStatus();
            var player1Index = _numberOfPlayers-1;
            var player = game.Players[player1Index];
            player.Position = _player1Location;
        }

        [When(@"the token is placed on the board")]
        public void WhenTheTokenIsPlacedOnTheBoard()
        {
            _sut = _serviceProvider.GetService<IPlayGameDomainService>();
            
            _sut.Build(_numberOfPlayers);
            var game = _sut.GetGameStatus();
            
            var player1Index = _numberOfPlayers-1;
            var player = game.Players[player1Index];
            player.Position = 1;
        }

        [When(@"the token is moved (.*) spaces")]
        [When(@"then it is moved (.*) spaces")]
        public void WhenTheTokenIsMovedSpaces(int roll)
        {
            var dieMock = (DieMock)_serviceProvider.GetService<IDie>();
            dieMock.ValueToThrow = roll;
            _sut.MakeMove();
        }

        [Then(@"the token is on square (.*)")]
        public void ThenTheTokenIsOnSquare(int expectedSquareNumber)
        {
            var game = _sut.GetGameStatus();
            var player1Index = _numberOfPlayers-1;
            var player = game.Players[player1Index];
            player.Position.Should().Be(expectedSquareNumber);
        }

        [Then(@"the player has won the game")]
        public void ThenThePlayerHasWonTheGame()
        {
            var game = _sut.GetGameStatus();
            var winner = game.Info.Winner;
            winner.Should().Be("Player 1");
            var isGameFinished = game.Info.IsFinished;
            isGameFinished.Should().BeTrue();
        }

        [Then(@"the player has not won the game")]
        public void ThenThePlayerHasNotWonTheGame()
        {
            var game = _sut.GetGameStatus();
            var winner = game.Info.Winner;
            winner.Should().BeNullOrEmpty();
            var isGameFinished = game.Info.IsFinished;
            isGameFinished.Should().BeFalse();
        }
    }
}