using System;
using System.Collections.Generic;
using System.Linq;
using Alba.CsConsoleFormat;
using SnakesAndLadders.Domain.SnakesAndLadders.Enums;
using SnakesAndLadders.Domain.SnakesAndLadders.Models;
using SnakesAndLadders.Domain.SnakesAndLadders.Models.Board;
using Cell = Alba.CsConsoleFormat.Cell;

namespace SnakesAndLadders.Client.Console
{
    public class GameConsoleRenderer
    {
        public static void RenderBoard(Board board)
        {
            var boardRows = 10;
            var boardColumns = 10;

            var table = new Grid();
            var columns = new List<Column>();
            for (int i = 0; i < 10; i++)
                columns.Add(new Column());

            table.Columns.Add(columns);

            var reversedColumnOrder = true;
            for (var row = boardRows - 1; row >= 0; row--)
            {
                var tableRow = new List<string>();
                for (var column = boardColumns - 1; column >= 0; column--)
                {
                    var cellNumber =
                        row * 10 +
                        (reversedColumnOrder ? column + 1 : 10 - column);
                    var boardCell = board.Cells[cellNumber];
                    var tableCell = $"{cellNumber.ToString()}{RenderCellType(boardCell.Type)}\n\n\n {boardCell.Effect} ";
                    tableRow.Add(tableCell);
                }

                table.Children.Add(tableRow.Select(x => new Cell(x)));
                reversedColumnOrder = !reversedColumnOrder;
            }

            var doc = new Document(table);

            ConsoleRenderer.RenderDocument(doc);
        }

        public static void RenderGameStatus(Game game)
        {
            System.Console.WriteLine($"Score:");
            foreach (var player in game.Players)
                System.Console.WriteLine($"    {player.Name}: {player.Position}");
            System.Console.WriteLine($"It's player {game.Info.ActivePlayer}'s turn!{Environment.NewLine}");
        }

        private static string RenderCellType(CellType boardCellType)
        {
            switch (boardCellType)
            {
                case CellType.Snake:
                    return "    Snake";
                case CellType.Ladder:
                    return "    Ladder";
                default:
                    return string.Empty;
            }
        }
    }
}