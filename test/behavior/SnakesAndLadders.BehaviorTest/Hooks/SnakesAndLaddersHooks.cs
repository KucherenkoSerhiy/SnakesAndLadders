using System;
using TechTalk.SpecFlow;

namespace SnakesAndLadders.BehaviorTest.Hooks
{
    [Binding]
    public sealed class SnakesAndLaddersHooks
    {
        [BeforeScenario]
        public static void BeforeScenario()
        {
            Console.WriteLine($"Starting {ScenarioContext.Current.ScenarioInfo.Title}");
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Console.WriteLine($"Finished {ScenarioContext.Current.ScenarioInfo.Title}");
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine($"Starting {featureContext.FeatureInfo.Title}");
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featureContext)
        {
            Console.WriteLine($"Finished {featureContext.FeatureInfo.Title}");
        }
    }
}