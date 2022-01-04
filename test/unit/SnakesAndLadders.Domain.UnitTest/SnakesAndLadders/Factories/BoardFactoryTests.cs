using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadders.Domain.SnakesAndLadders.Factories.Impl;
using SnakesAndLadders.Domain.SnakesAndLadders.Models.Board;

namespace SnakesAndLadders.Domain.UnitTest.SnakesAndLadders.Factories
{
    [TestClass]
    public class BoardFactoryTests
    {
        /// <summary>
        /// The first number is the head; the last one is the tail
        /// </summary>
        private readonly List<int> _snakes = new() {16, 46, 49, 62, 64, 74, 89, 92, 95, 99};
        
        /// <summary>
        /// The first number is the bottom; the last one is the top
        /// </summary>
        private readonly List<int> _ladders = new() {2, 7, 8, 15, 21, 28, 36, 51, 71, 78, 87};
        
        [TestMethod]
        public void Build_ValidCase_Ok()
        {
            var sut = new BoardFactory();
            var board = sut.Build();
            
            board.Cells.Count.Should().Be(100);
            
            foreach (var snake in _snakes)
                board.Cells[snake].Should().BeOfType<Snake>();
            foreach (var ladder in _ladders)
                board.Cells[ladder].Should().BeOfType<Ladder>();
            var emptyCells = Enumerable.Range(1, 100).Except(_snakes).Except(_ladders);
            foreach (var emptyCell in emptyCells)
                board.Cells[emptyCell].Should().BeOfType<EmptyCell>();
        }
    }
}