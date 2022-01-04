using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SnakesAndLadders.Domain.SnakesAndLadders.Containers;
using SnakesAndLadders.Domain.SnakesAndLadders.Containers.Impl;
using SnakesAndLadders.Domain.SnakesAndLadders.Factories;
using SnakesAndLadders.Domain.SnakesAndLadders.Factories.Impl;
using SnakesAndLadders.Domain.SnakesAndLadders.Services;
using SnakesAndLadders.Domain.SnakesAndLadders.Services.Impl;
using SnakesAndLadders.Infrastructure.SnakesAndLadders.DomainServices;

namespace SnakesAndLadders.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = SetupIoCContainer();

            var dependencyFacade = serviceProvider.GetService<IPlayGameDomainService>();
            
            SetUpGame(dependencyFacade);
            PlayGame(dependencyFacade);
        }

        private static ServiceProvider SetupIoCContainer()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(configure => configure.AddConsole());
            AddServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }

        private static void AddServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPlayGameDomainService, PlayGameDomainService>();
            
            serviceCollection.AddSingleton<IGameContainer, GameContainer>();
            
            serviceCollection.AddTransient<IGameFactory, GameFactory>();
            serviceCollection.AddTransient<IPlayerFactory, PlayerFactory>();
            serviceCollection.AddTransient<IBoardFactory, BoardFactory>();
            
            serviceCollection.AddTransient<IDie, OneDie6>();
        }

        private static void SetUpGame(IPlayGameDomainService dependencyFacade)
        {
            System.Console.WriteLine("Welcome to Snakes and Ladders!");
            System.Console.WriteLine("Number of players (between 1 and 4):");

            int numberOfPlayers;
            while (!int.TryParse(System.Console.ReadLine(), out numberOfPlayers)
                   && numberOfPlayers is <= 0 or >= 4)
            {
                System.Console.WriteLine("Please enter a valid number of players (between 1 and 4)");
            }

            dependencyFacade.Build(numberOfPlayers);
            
            var game = dependencyFacade.GetGameStatus();
            GameConsoleRenderer.RenderBoard(game.Board);
        }

        private static void PlayGame(IPlayGameDomainService dependencyFacade)
        {
            var exitWord = "exit";
            while (true)
            {
                System.Console.WriteLine($"Press ENTER to make next move. Type {exitWord} to quit the game");
                var userAction = System.Console.ReadLine();
                if (userAction.Equals(exitWord, StringComparison.InvariantCultureIgnoreCase))
                    return;
                
                dependencyFacade.MakeMove();
                var game = dependencyFacade.GetGameStatus();
                GameConsoleRenderer.RenderGameStatus(game);
                if (game.Info.IsFinished)
                    return;
            }
        }
    }
}