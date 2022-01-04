using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SnakesAndLadders.BehaviorTest.Mocks;
using SnakesAndLadders.Domain.SnakesAndLadders.Services;
using TechTalk.SpecFlow;

namespace SnakesAndLadders.BehaviorTest.Steps
{
    [Binding]
    [Scope(Feature = "Moves Are Determined By Dice Rolls")]
    public sealed class DiceSteps
    {
        private readonly int _numberOfPlayers = 1;
        private const int TotalRolls = 10000;
        private IDie _die;
        private Dictionary<int, int> _rolledValues;
        private IPlayGameDomainService _sut;
        private readonly ServiceCollection _serviceCollection;

        public DiceSteps()
        {
            _serviceCollection = IoCSetup.SetupIoCContainer();
        }
        
        [Given(@"the game is started")]
        public void GivenTheGameIsStarted()
        {
            _rolledValues = new Dictionary<int, int>();
            var serviceProvider = _serviceCollection.BuildServiceProvider();
            _die = serviceProvider.GetService<IDie>();
        }
        
        [Given(@"the player rolls a (.*)")]
        public void GivenThePlayerRollsA(int dieRoll)
        {
            _serviceCollection.Replace(ServiceDescriptor.Scoped<IDie, DieMock>());
            var serviceProvider = _serviceCollection.BuildServiceProvider();
            var dieMock = (DieMock)serviceProvider.GetService<IDie>();
            dieMock.ValueToThrow = dieRoll;
            
            _sut = serviceProvider.GetService<IPlayGameDomainService>();
            _sut.Build(_numberOfPlayers);
        }

        [When(@"the player rolls a die")]
        public void WhenThePlayerRollsADie()
        {
            for (var i = 0; i < TotalRolls; i++)
            {
                var roll = _die.Roll();
                if (!_rolledValues.ContainsKey(roll))
                    _rolledValues[roll] = 1;
                else 
                    _rolledValues[roll] ++;
            }
        }

        [When(@"they move their token")]
        public void WhenTheyMoveTheirToken()
        {
            _sut.MakeMove();
        }


        [Then(@"the result should be between 1-6 inclusive")]
        public void ThenTheResultShouldBeBetweenInclusive()
        {
            var validRolls = 0;
            for (var i = 1; i <= 6; i++)
                validRolls += _rolledValues[i];
            validRolls.Should().Be(TotalRolls);
        }

        [Then(@"the token should move (.*) spaces")]
        public void ThenTheTokenShouldMoveSpaces(int spaces)
        {
            var game = _sut.GetGameStatus();
            var firstPlayerIndex = _numberOfPlayers-1;
            var player = game.Players[firstPlayerIndex];
            var startingPlayerPosition = 1;
            player.Position.Should().Be(spaces+startingPlayerPosition);
        }
    }
}