using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_Tic_Tac_Toe.Classes
{
    class GameBoard
    {
        public string[][] Layout { get; set; }
        public string[][] defaultLayout = new string[][]
            {
                    new string[] { "1", "2", "3" },
                    new string[] { "4", "5", "6" },
                    new string[] { "7", "8", "9" }
            };
        public GameBoard()
        {
            Layout = defaultLayout;
        }

        public void DisplayBoard(string[][] datBoard)
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
        }

        public string[][] UpdateBoard(string num, string[][] datBoard, string marker)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (num == datBoard[i][j])
                        datBoard[i][j] = marker;
                }
            }
            return datBoard;
        }
    }
}
