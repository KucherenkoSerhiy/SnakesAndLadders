using System.Collections.Generic;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Models.Board
{
    public class Board
    {
        public Dictionary<int, Cell> Cells { get; set; }
    }
}