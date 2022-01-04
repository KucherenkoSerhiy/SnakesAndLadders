using SnakesAndLadders.Domain.SnakesAndLadders.Enums;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Models.Board
{
    public class Snake: Cell
    {
        public int Tail { get; init; }
        public override CellType Type => CellType.Snake;
        public override string Effect => $"Move to {Tail}";
        
        public override void MovePlayer(PlayerToken playerToken)
        {
            playerToken.Position = Tail;
        }
    }
}