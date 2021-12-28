namespace SnakesAndLadders.Domain.SnakesAndLadders.Models
{
    public class GameInfo
    {
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }
        public PlayerToken Winner { get; set; }
    }
}