using SnakesAndLadders.Domain.SnakesAndLadders.Enums;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Models.Board
{
    public class EmptyCell: Cell
    {
        public override void MovePlayer(PlayerToken playerToken) { }
        public override CellType Type => CellType.EmptyCell;
        public override string Effect => string.Empty;
    }
}