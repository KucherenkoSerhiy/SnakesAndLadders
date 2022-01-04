using System;
using SnakesAndLadders.Domain.SnakesAndLadders.Containers;
using SnakesAndLadders.Domain.SnakesAndLadders.Factories;
using SnakesAndLadders.Domain.SnakesAndLadders.Models;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Services.Impl
{
    public class PlayGameDomainService : IPlayGameDomainService
    {
        private readonly IGameFactory _gameFactory;
        private readonly IGameContainer _gameContainer;
        private readonly IDie _die;

        public PlayGameDomainService(IGameFactory gameFactory, IGameContainer gameContainer, IDie die)
        {
            _gameFactory = gameFactory;
            _gameContainer = gameContainer;
            _die = die;
        }
        
        public void Build(int numberOfPlayers)
        {
            var game = _gameFactory.Build(numberOfPlayers);
            _gameContainer.Game = game;
        }

        public void MakeMove()
        {
            var game = _gameContainer.Game;
            if (game.Info.IsFinished)
                throw new ApplicationException("The game is already finished. Start again.");

            var activePlayerIndex = game.Info.ActivePlayer - 1;
            var activePlayer = game.Players[activePlayerIndex];
            MovePlayer(activePlayer, game);

            if (activePlayer.Position == Game.LastCellNumber)
            {
                FinishTheGame(game);
            }
            else
            {
                SelectNextPlayer(game);
            }
        }

        public Game GetGameStatus()
        {
            var game = _gameContainer.Game;
            return game;
        }

        private void MovePlayer(PlayerToken player, Game game)
        {
            var roll = _die.Roll();
            if (player.Position + roll > Game.LastCellNumber)
                return;

            player.Position += roll;
            var cell = game.Board.Cells[player.Position];
            cell.MovePlayer(player);
        }

        private static void FinishTheGame(Game game)
        {
            var activePlayerIndex = game.Info.ActivePlayer - 1;
            var winnerName = game.Players[activePlayerIndex].Name;
            game.Info.Winner = winnerName;
            game.Info.IsFinished = true;
        }

        private static void SelectNextPlayer(Game game)
        {
            game.Info.ActivePlayer++;
            if (game.Info.ActivePlayer > game.Players.Count)
                game.Info.ActivePlayer -= game.Players.Count;
        }
    }
}