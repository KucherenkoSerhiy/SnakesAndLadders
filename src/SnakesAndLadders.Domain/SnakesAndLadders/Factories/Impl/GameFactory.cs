using System;
using System.Collections.Generic;
using SnakesAndLadders.Domain.SnakesAndLadders.Models;

namespace SnakesAndLadders.Domain.SnakesAndLadders.Factories.Impl
{
    public class GameFactory: IGameFactory
    {
        private readonly IPlayerFactory _playerFactory;
        private readonly IBoardFactory _boardFactory;

        public GameFactory(IPlayerFactory playerFactory, IBoardFactory boardFactory)
        {
            _playerFactory = playerFactory;
            _boardFactory = boardFactory;
        }
        
        public Game Build(int numberOfPlayers)
        {
            var board = _boardFactory.Build();
            var players = _playerFactory.Build(numberOfPlayers);
            
            var game = new Game
            {
                Board = board,
                Info = new GameInfo
                {
                    IsStarted = true,
                    IsFinished = false,
                    ActivePlayer = 1
                },
                Players = players
            };
            
            return game;
        }
    }
}