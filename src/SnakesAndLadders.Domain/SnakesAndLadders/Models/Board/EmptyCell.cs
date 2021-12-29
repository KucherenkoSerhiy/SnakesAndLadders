namespace SnakesAndLadders.Domain.SnakesAndLadders.Models.Board
{
    public class EmptyCell: Cell
    {
        public override void MovePlayer(PlayerToken playerToken) { }
    }
}