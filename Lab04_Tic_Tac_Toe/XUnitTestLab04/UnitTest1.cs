using System;
using Xunit;
using Lab04_Tic_Tac_Toe;
using static Lab04_Tic_Tac_Toe.Program;
using Lab04_Tic_Tac_Toe.Classes;

namespace XUnitTestLab04
{
    public class UnitTest1
    {

        [Fact]
        public void CanWinDiagonal()
        {
            string[][] testBoard = new string[][]
            {
                    new string[] { "X", "2", "3" },
                    new string[] { "4", "X", "6" },
                    new string[] { "7", "8", "X" }
            };
            string marker = "X";

            Assert.True(GameBoard.CheckForWin(testBoard, marker));
        }

        [Fact]
        public void CanWinHorizontal()
        {
            string[][] testBoard = new string[][]
            {
                    new string[] { "1", "2", "3" },
                    new string[] { "X", "X", "X" },
                    new string[] { "7", "8", "9" }
            };
            string marker = "X";

            Assert.True(GameBoard.CheckForWin(testBoard, marker));
        }

        [Fact]
        public void CanWinVertical()
        {
            string[][] testBoard = new string[][]
            {
                    new string[] { "1", "O", "3" },
                    new string[] { "4", "O", "6" },
                    new string[] { "7", "O", "9" }
            };
            string marker = "O";

            Assert.True(GameBoard.CheckForWin(testBoard, marker));
        }

        [Fact]
        public void CanBecomeInctivePlayer()
        {
            Player p = new Player("Bob", "X", true);
            Assert.False(p.ChangePlayer(p.IsActive));
        }

        [Fact]
        public void CanBecomeActivePlayer()
        {
            Player p = new Player("Joe", "O", false);
            Assert.True(p.ChangePlayer(p.IsActive));
        }

        [Fact]
        public void CanInputToCorrectIndex()
        {
            Player p = new Player("Ted", "O", false);
            GameBoard testBoardObj = new GameBoard();
            string num = "5";
            string[][] expectedBoard = new string[][]
            {
                    new string[] { "1", "2", "3" },
                    new string[] { "4", "O", "6" },
                    new string[] { "7", "8", "9" }
            };
            Assert.Equal(expectedBoard, testBoardObj.UpdateBoard(num, testBoardObj.Layout, p.Marker));
        }

        [Fact]
        public void CanDraw()
        {
            string[][] testBoard = new string[][]
            {
                    new string[] { "X", "O", "X" },
                    new string[] { "O", "O", "X" },
                    new string[] { "X", "X", "O" }
            };
            Assert.False(GameBoard.CheckForWin(testBoard, "X"));
            Assert.False(GameBoard.CheckForWin(testBoard, "O"));
        }
    }
}
