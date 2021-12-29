using SnakesAndLadders.Domain.SnakesAndLadders.Models.Board;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Factories
{
    public interface IBoardFactory
    {
        Board Build();
    }
}