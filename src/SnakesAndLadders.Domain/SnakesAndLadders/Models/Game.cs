using System.Collections.Generic;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Models
{
    public class Game
    {
        public const int LastCellNumber = 100;
        public GameInfo Info { get; set; }
        public List<PlayerToken> Players { get; set; }
        public Board.Board Board { get; set; }
    }
}