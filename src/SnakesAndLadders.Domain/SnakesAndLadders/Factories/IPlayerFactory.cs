using System.Collections.Generic;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Factories
{
    public interface IPlayerFactory
    {
        List<PlayerToken> Build(int numberOfPlayers);
    }
}