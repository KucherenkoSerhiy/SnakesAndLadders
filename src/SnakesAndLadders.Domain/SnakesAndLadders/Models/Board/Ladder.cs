namespace SnakesAndLadders.Domain.SnakesAndLadders.Models.Board
{
    public class Ladder : Cell
    {
        public int Head { get; set; }
        
        public override void MovePlayer(PlayerToken playerToken)
        {
            playerToken.Position = Head;
        }
    }
}