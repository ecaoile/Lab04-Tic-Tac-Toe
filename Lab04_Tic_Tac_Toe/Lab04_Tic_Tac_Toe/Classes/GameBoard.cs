using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_Tic_Tac_Toe.Classes
{
    /// <summary>
    /// class that creates a game board and handles game board changes
    /// </summary>
    class GameBoard
    {
        public string[][] Layout { get; set; }
        public string[][] Taken { get; set; }
        public string[][] defaultLayout = new string[][]
            {
                    new string[] { "1", "2", "3" },
                    new string[] { "4", "5", "6" },
                    new string[] { "7", "8", "9" }
            };

        public string[][] defaultTaken = new string[][]
        {
            new string[3] ,
            new string[3] ,
            new string[3]
        };

        public GameBoard()
        {
            Layout = defaultLayout;
            Taken = defaultTaken;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="datBoard"></param>
        /// <returns></returns>
        public bool DisplayBoard(string[][] datBoard)
        {
            if (datBoard.Length != 3)
                return false;
            try
            {
                Console.WriteLine("Current game board:");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"|{datBoard[i][j]}|");
                    }
                    Console.WriteLine();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in making the board: {e.Message}");
                return false;
            }
        }

        /// <summary>
        /// method for updating the board with the last user's input
        /// </summary>
        /// <param name="num">the number which designates the space the user chose</param>
        /// <param name="datBoard">the current board board in play</param>
        /// <param name="marker">marker of the current player</param>
        /// <returns>the updated board containing the last marker</returns>
        public string[][] UpdateBoard(string num, string[][] datBoard, string marker)
        {
            try
            {
                if (datBoard.Length != 3)
                {
                    return defaultLayout;
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (num == datBoard[i][j])
                        {
                            Taken[i][j] = datBoard[i][j];
                            datBoard[i][j] = marker;
                        }
                    }
                }
                return datBoard;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error trying to update the board: {e.Message}.");
                return defaultLayout;
            }
        }
    }
}
