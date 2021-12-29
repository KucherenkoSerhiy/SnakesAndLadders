namespace SnakesAndLadders.Domain.SnakesAndLadders.Models
{
    public class GameInfo
    {
        public bool IsStarted { get; set; }
        public bool IsFinished { get; set; }
        public int ActivePlayer { get; set; }
        public int Winner { get; set; }
    }
}