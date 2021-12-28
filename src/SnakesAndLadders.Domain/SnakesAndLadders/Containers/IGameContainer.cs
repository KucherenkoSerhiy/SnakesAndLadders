using SnakesAndLadders.Domain.SnakesAndLadders.Models;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Containers
{
    public interface IGameContainer
    {
        public Game Game { get; set; }
    }
}