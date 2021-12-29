using SnakesAndLadders.Domain.SnakesAndLadders.Models;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Containers.Impl
{
    public class GameContainer : IGameContainer
    {
        public Game Game { get; set; }
    }
}