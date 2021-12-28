using SnakesAndLadders.Domain.SnakesAndLadders.Models;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Services
{
    public interface IPlayGameDomainService
    {
        void Build(int numberOfPlayers);
        void MakeMove();
        Game GetGameStatus();
    }
}