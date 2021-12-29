using SnakesAndLadders.Domain.SnakesAndLadders.Models.Board;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Models
{
    public class PlayerToken
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public bool IsTheirTurn { get; set; }
    }
}