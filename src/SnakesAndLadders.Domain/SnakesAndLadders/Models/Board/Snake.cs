namespace SnakesAndLadders.Domain.SnakesAndLadders.Models.Board
{
    public class Snake: Cell
    {
        public int Tail { get; set; }
        
        public override void MovePlayer(PlayerToken playerToken)
        {
            playerToken.Position = Tail;
        }
    }
}