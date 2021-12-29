using System;
using SnakesAndLadders.Domain.SnakesAndLadders.Services;

namespace SnakesAndLadders.Infrastructure.SnakesAndLadders.DomainServices
{
    public class OneDie6: IDie
    {
        private const int MinValue = 1;
        private const int MaxValue = 6;
        private readonly Random _rng;

        public OneDie6()
        {
            _rng = new Random();
        }
        
        public int Roll()
        {
            var roll = _rng.Next(MinValue, MaxValue + 1);
            return roll;
        }
    }
}