using System;
using System.Collections.Generic;
using SnakesAndLadders.Domain.SnakesAndLadders.Models;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Factories.Impl
{
    public class PlayerFactory: IPlayerFactory
    {
        public List<PlayerToken> Build(int numberOfPlayers)
        {
            if (numberOfPlayers <= 0)
                throw new ArgumentException(nameof(numberOfPlayers));
            
            var players = new List<PlayerToken>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                var player = new PlayerToken
                {
                    Name = $"Player {i}",
                    Position = 1,
                    IsTheirTurn = false
                };
                players.Add(player);
            }

            players[0].IsTheirTurn = true;

            return players;
        }
    }
}