using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SnakesAndLadders.Domain.SnakesAndLadders.Containers;
using SnakesAndLadders.Domain.SnakesAndLadders.Containers.Impl;
using SnakesAndLadders.Domain.SnakesAndLadders.Factories;
using SnakesAndLadders.Domain.SnakesAndLadders.Factories.Impl;
using SnakesAndLadders.Domain.SnakesAndLadders.Services;
using SnakesAndLadders.Domain.SnakesAndLadders.Services.Impl;
using SnakesAndLadders.Infrastructure.SnakesAndLadders.DomainServices;

namespace SnakesAndLadders.BehaviorTest
{
    public static class IoCSetup
    {
        public static ServiceCollection SetupIoCContainer()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(configure => configure.AddConsole());
            AddServices(serviceCollection);
            return serviceCollection;
        }

        private static void AddServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPlayGameDomainService, PlayGameDomainService>();
            
            serviceCollection.AddSingleton<IGameContainer, GameContainer>();
            
            serviceCollection.AddTransient<IGameFactory, GameFactory>();
            serviceCollection.AddTransient<IPlayerFactory, PlayerFactory>();
            serviceCollection.AddTransient<IBoardFactory, BoardFactory>();
            
            serviceCollection.AddScoped<IDie, OneDie6>();
        }
    }
}