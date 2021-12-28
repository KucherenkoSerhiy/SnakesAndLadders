using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SnakesAndLadders.BehaviorTest.Steps
{
    [Binding]
    [Scope(Feature = "Token Can Move Across The Board")]
    public sealed class SnakesAndLaddersSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public SnakesAndLaddersSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the game is started")]
        public void GivenTheGameIsStarted()
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"the token is on square (.*)")]
        public void GivenTheTokenIsOnSquare(int p0)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"the player rolls a (.*)")]
        public void GivenThePlayerRollsA(int p0)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"the token is placed on the board")]
        public void WhenTheTokenIsPlacedOnTheBoard()
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"the token is moved (.*) spaces")]
        public void WhenTheTokenIsMovedSpaces(int p0)
        {
            ScenarioContext.StepIsPending();
        }


        [When(@"then it is moved (.*) spaces")]
        public void WhenThenItIsMovedSpaces(int p0)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"they move their token")]
        public void WhenTheyMoveTheirToken()
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"the player rolls a die")]
        public void WhenThePlayerRollsADie()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"the token is on square (.*)")]
        public void ThenTheTokenIsOnSquare(int p0)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"the player has won the game")]
        public void ThenThePlayerHasWonTheGame()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"the player has not won the game")]
        public void ThenThePlayerHasNotWonTheGame()
        {
            ScenarioContext.StepIsPending();
        }


        [Then(@"the result should be between (.*) inclusive")]
        public void ThenTheResultShouldBeBetweenInclusive(string p0)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"the token should move (.*) spaces")]
        public void ThenTheTokenShouldMoveSpaces(int p0)
        {
            ScenarioContext.StepIsPending();
        }
    }
}