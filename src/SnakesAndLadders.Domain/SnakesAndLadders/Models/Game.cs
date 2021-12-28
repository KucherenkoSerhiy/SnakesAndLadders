using System.Collections.Generic;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Models
{
    public class Game
    {
        public GameInfo Info { get; set; }
        public List<PlayerToken> Players { get; set; }
        public Board.Board Board { get; set; }
    }
}