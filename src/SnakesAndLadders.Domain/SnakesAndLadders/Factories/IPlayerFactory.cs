using System.Collections.Generic;
using SnakesAndLadders.Domain.SnakesAndLadders.Models;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Factories
{
    public interface IPlayerFactory
    {
        List<PlayerToken> Build(int numberOfPlayers);
    }
}