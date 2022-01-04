using SnakesAndLadders.Domain.SnakesAndLadders.Enums;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Models.Board
{
    public abstract class Cell
    {
        public abstract CellType Type { get; }
        public abstract string Effect { get; }
        public abstract void MovePlayer(PlayerToken playerToken);
    }
}