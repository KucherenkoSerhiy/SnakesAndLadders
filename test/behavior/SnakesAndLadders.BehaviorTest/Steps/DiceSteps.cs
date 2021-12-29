using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using SnakesAndLadders.Domain.SnakesAndLadders.Services;
using TechTalk.SpecFlow;

namespace SnakesAndLadders.BehaviorTest.Steps
{
    [Binding]
    [Scope(Feature = "Moves Are Determined By Dice Rolls")]
    public sealed class DiceSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IDie _die;
        private Dictionary<int, int> _rolledValues;
        private const int TotalRolls = 10000;

        public DiceSteps(ScenarioContext scenarioContext, IDie die)
        {
            _scenarioContext = scenarioContext;
            _die = die;
        }
        
        [Given(@"the game is started")]
        public void GivenTheGameIsStarted()
        {
            _rolledValues = new Dictionary<int, int>();
        }
        
        [Given(@"the player rolls a (.*)")]
        public void GivenThePlayerRollsA(int p0)
        {
            ScenarioContext.StepIsPending();
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
            ScenarioContext.StepIsPending();
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
        public void ThenTheTokenShouldMoveSpaces(int p0)
        {
            ScenarioContext.StepIsPending();
        }
    }
}