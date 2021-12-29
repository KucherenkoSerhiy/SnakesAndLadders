using System.Linq;
using FluentAssertions;
using SnakesAndLadders.Domain.SnakesAndLadders.Models;
using SnakesAndLadders.Domain.SnakesAndLadders.Services;
using TechTalk.SpecFlow;

namespace SnakesAndLadders.BehaviorTest.Steps
{
    [Binding]
    [Scope(Feature = "Token Can Move Across The Board")]
    [Scope(Feature = "Player Can Win the Game")]
    public sealed class SnakesAndLaddersSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IPlayGameDomainService _playGameDomainService;

        public SnakesAndLaddersSteps(
            ScenarioContext scenarioContext, IPlayGameDomainService playGameDomainService)
        {
            _scenarioContext = scenarioContext;
            _playGameDomainService = playGameDomainService;
        }

        [Given(@"the game is started")]
        public void GivenTheGameIsStarted()
        {
            
        }

        [Given(@"the token is on square (.*)")]
        public void GivenTheTokenIsOnSquare(int squareNumber)
        {
            var game = (Game)_scenarioContext["Game"];
            var player = game.Players.First();
            player.Position = squareNumber;
        }

        [When(@"the token is placed on the board")]
        public void WhenTheTokenIsPlacedOnTheBoard()
        {
            
        }

        [When(@"the token is moved (.*) spaces")]
        [When(@"then it is moved (.*) spaces")]
        public void WhenTheTokenIsMovedSpaces(int spaces)
        {
            var game = (Game)_scenarioContext["Game"];
            var player = game.Players.First();
            player.Position += spaces;
        }

        [Then(@"the token is on square (.*)")]
        public void ThenTheTokenIsOnSquare(int expectedSquareNumber)
        {
            var game = (Game)_scenarioContext["Game"];
            var player = game.Players.First();
            player.Position.Should().Be(expectedSquareNumber);
        }

        [Then(@"the player has won the game")]
        public void ThenThePlayerHasWonTheGame()
        {
            var game = (Game)_scenarioContext["Game"];
            var winner = game.Info.Winner;
            winner.Should().NotBeNull();
            var isGameFinished = game.Info.IsFinished;
            isGameFinished.Should().BeTrue();
        }

        [Then(@"the player has not won the game")]
        public void ThenThePlayerHasNotWonTheGame()
        {
            var game = (Game)_scenarioContext["Game"];
            var winner = game.Info.Winner;
            winner.Should().BeNull();
            var isGameFinished = game.Info.IsFinished;
            isGameFinished.Should().BeFalse();
        }
    }
}