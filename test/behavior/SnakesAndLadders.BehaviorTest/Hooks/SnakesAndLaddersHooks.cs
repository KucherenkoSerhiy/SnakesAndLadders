using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnakesAndLadders.Domain.SnakesAndLadders.Services;
using TechTalk.SpecFlow;

namespace SnakesAndLadders.BehaviorTest.Hooks
{
    [Binding]
    public sealed class SnakesAndLaddersHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IPlayGameDomainService _playGameDomainService;

        public SnakesAndLaddersHooks(ScenarioContext scenarioContext, IPlayGameDomainService playGameDomainService)
        {
            _scenarioContext = scenarioContext;
            _playGameDomainService = playGameDomainService;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine($"Starting {_scenarioContext.ScenarioInfo.Title}");
            
            var numberOfPlayers = 1;
            _playGameDomainService.Build(numberOfPlayers);
            _scenarioContext["Game"] = _playGameDomainService.GetGameStatus();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine($"Finished {_scenarioContext.ScenarioInfo.Title}");
        }

        [BeforeFeature]
        public void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine($"Starting {featureContext.FeatureInfo.Title}");
        }

        [AfterFeature]
        public void AfterFeature(FeatureContext featureContext)
        {
            Console.WriteLine($"Finished {featureContext.FeatureInfo.Title}");
        }
    }
}