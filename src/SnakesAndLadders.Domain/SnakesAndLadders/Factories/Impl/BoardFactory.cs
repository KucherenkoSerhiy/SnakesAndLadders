using System.Collections.Generic;
using SnakesAndLadders.Domain.SnakesAndLadders.Models.Board;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Factories.Impl
{
    public class BoardFactory : IBoardFactory
    {
        /// <summary>
        /// The first number is the head; the last one is the tail
        /// </summary>
        private readonly Dictionary<int, int> _snakes = new()
        {
            {16, 6}, {46, 25}, {49, 11}, {62, 19}, {64, 60},
            {74, 53}, {89, 68}, {92, 88}, {95, 75}, {99, 80}
        };
        
        /// <summary>
        /// The first number is the bottom; the last one is the top
        /// </summary>
        private readonly Dictionary<int, int> _ladders = new()
        {
            {2, 38}, {7, 14}, {8, 31}, {15, 26}, {21, 42}, {28, 84}, 
            {36, 44}, {51, 67}, {71, 91}, {78, 98}, {87, 94}
        };

        public Board Build()
        {
            var cells = new Dictionary<int, Cell>();
            for (var i = 1; i <= 100; i++)
            {
                if (_snakes.ContainsKey(i))
                    cells[i] = new Snake {Tail = _snakes[i]};
                else if (_ladders.ContainsKey(i))
                    cells[i] = new Ladder {Head = _ladders[i]};
                else
                    cells[i] = new EmptyCell();
            }
                
            var board = new Board
            {
                Cells = cells
            };
            
            return board;
        }
    }
}