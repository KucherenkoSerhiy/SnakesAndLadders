using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SnakesAndLadders.BehaviorTest.Hooks
{
    [Binding]
    public sealed class SnakesAndLaddersHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public SnakesAndLaddersHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine($"Starting {_scenarioContext.ScenarioInfo.Title}");
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