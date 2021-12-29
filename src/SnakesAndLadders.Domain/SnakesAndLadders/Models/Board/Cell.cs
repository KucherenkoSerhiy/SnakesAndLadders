namespace SnakesAndLadders.Domain.SnakesAndLadders.Models.Board
{
    public abstract class Cell
    {
        public abstract void MovePlayer(PlayerToken playerToken);
    }
}