using System;
using Microsoft.Extensions.Logging;
using SnakesAndLadders.Domain.SnakesAndLadders.Services;

namespace SnakesAndLadders.Infrastructure.SnakesAndLadders.DomainServices
{
    public class OneDie6: IDie
    {
        private readonly ILogger<OneDie6> _logger;
        private const int MinValue = 1;
        private const int MaxValue = 6;
        private readonly Random _rng;

        public OneDie6(ILogger<OneDie6> logger)
        {
            _logger = logger;
            _rng = new Random();
        }
        
        public int Roll()
        {
            var roll = _rng.Next(MinValue, MaxValue + 1);
            _logger.Log(LogLevel.Information, $"Rolled {roll}");
            return roll;
        }
    }
}