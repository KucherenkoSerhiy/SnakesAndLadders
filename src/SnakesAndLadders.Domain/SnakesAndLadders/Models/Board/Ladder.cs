using SnakesAndLadders.Domain.SnakesAndLadders.Enums;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Models.Board
{
    public class Ladder : Cell
    {
        public int Head { get; init; }

        public override CellType Type => CellType.Ladder;

        public override string Effect => $"Move to {Head}";

        public override void MovePlayer(PlayerToken playerToken)
        {
            playerToken.Position = Head;
        }
    }
}