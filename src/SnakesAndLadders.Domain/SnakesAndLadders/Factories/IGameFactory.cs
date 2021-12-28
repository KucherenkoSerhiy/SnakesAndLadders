using SnakesAndLadders.Domain.SnakesAndLadders.Models;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Factories
{
    public interface IGameFactory
    {
        Game Build(int numberOfPlayers);
    }
}