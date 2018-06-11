using Lab04_Tic_Tac_Toe.Classes;
using System;

namespace Lab04_Tic_Tac_Toe
{
    class Program
    {
        /// <summary>
        /// main entry point to the lab: opens up the game console and starts a tic-tac-toe game
        /// </summary>
        /// <param name="args">some stuff needed to run a main method...</param>
        static void Main(string[] args)
        {
            PlayGame();
            Console.WriteLine("Thank you for playing! Press any button to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// method that runs the game
        /// </summary>
        public static void PlayGame()
        {
            bool runProgram = true;

            Console.WriteLine("Welcome to Lab 04: Tic-Tac-Toe!\n");
            while (runProgram == true)
            {
                bool player1Win = false;
                bool player2Win = false;
                int roundNum = 1;
                Console.WriteLine("Player 1, please enter your name:");
                string player1Name = Console.ReadLine();
                while (player1Name == "")
                {
                    Console.WriteLine("Please enter SOMETHING for a name.");
                    player1Name = Console.ReadLine();
                }
                Player player1 = new Player(player1Name, "X");

                Console.WriteLine("Player 2, please enter your name:");
                string player2Name = Console.ReadLine();
                while (player2Name == "")
                {
                    Console.WriteLine("Please enter SOMETHING for a name.");
                    player2Name = Console.ReadLine();
                }
                Player player2 = new Player(player2Name, "O");

                Console.Clear();
                Console.WriteLine($"Welcome, {player1.Name} and {player2.Name}.");
                Console.WriteLine($"{player1.Name}'s marker: {player1.Marker}.");
                Console.WriteLine($"{player2.Name}'s marker: {player2.Marker}.");
                Console.WriteLine($"Rouund {roundNum}...FIGHT!");

                GameBoard datGameBoard = new GameBoard();
                bool takingTurns = true;
                int turn = 1;
                while (takingTurns == true)
                {
                    Console.WriteLine();
                    datGameBoard.DisplayBoard(datGameBoard.Layout);
                    if (turn % 2 != 0)
                        Console.WriteLine($"{player1.Name}'s turn ({player1.Marker}).");
                    else
                        Console.WriteLine($"{player2.Name}'s turn ({player2.Marker}).");

                    Console.WriteLine("Choose a number.");
                    string chosenNum = Console.ReadLine();
                    bool choseUnique = false;

                    while (choseUnique == false)
                    {
                        bool foundMatch = false;
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (datGameBoard.Taken[i][j] == chosenNum)
                                    foundMatch = true;
                            }
                        }
                        if (foundMatch == false)
                            choseUnique = true;
                        else
                        {
                            Console.WriteLine("That position is already taken!");
                            chosenNum = Console.ReadLine();
                        }
                    }


                    if (turn % 2 != 0)
                    {
                        datGameBoard.Layout = datGameBoard.UpdateBoard(chosenNum, datGameBoard.Layout, player1.Marker);
                        player1Win = CheckForWin(datGameBoard.Layout, player1.Marker);
                    }
                    if (turn % 2 == 0)
                    {
                        datGameBoard.Layout = datGameBoard.UpdateBoard(chosenNum, datGameBoard.Layout, player2.Marker);
                        player2Win = CheckForWin(datGameBoard.Layout, player2.Marker);
                    }
                    if (player1Win == true || player2Win == true)
                        takingTurns = false;
                    if (turn == 9)
                        takingTurns = false;
                    turn++;
                }

                if (player1Win == true)
                    Console.WriteLine("Player 1 wins!");
                if (player2Win == true)
                    Console.WriteLine("Player 2 wins!");

                if (player1Win == false && player2Win == false)
                {
                    Console.WriteLine("It's a draw!");
                }

                Console.WriteLine("\nGame over! Play again?");
                string playAgain = Console.ReadLine().ToLower();
                while (playAgain != "y" && playAgain != "yes" && playAgain != "n" && playAgain != "no")
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    playAgain = Console.ReadLine().ToLower();
                }

                if (playAgain == "y" || playAgain == "yes")
                {
                    Console.Clear();
                    Console.WriteLine("Let's do this again!");
                    roundNum++;
                }
                else
                    runProgram = false;
            }
        }

        /// <summary>
        /// method that checks whether a player won
        /// </summary>
        /// <param name="datBoard">the current board with the chosen spaces marked</param>
        /// <param name="marker">the marker being checked for a win</param>
        /// <returns>true if the player won and false if they didn't or an error occurred</returns>
        public static bool CheckForWin(string[][] datBoard, string marker)
        {
            // allow only X and O for markers
            if (marker != "X" && marker != "O")
                return false;
            try
            {
                string topLeft = datBoard[0][0];
                string topCenter = datBoard[0][1];
                string topRight = datBoard[0][2];
                string centerLeft = datBoard[1][0];
                string datCenter = datBoard[1][1];
                string centerRight = datBoard[1][2];
                string bottomLeft = datBoard[2][0];
                string bottomCenter = datBoard[2][1];
                string bottomRight = datBoard[2][2];

                // check for horizontal values
                if (topLeft == marker && topCenter == marker && topRight == marker)
                    return true;
                if (centerLeft == marker && datCenter == marker && centerRight == marker)
                    return true;
                if (bottomLeft == marker && bottomCenter == marker && bottomRight == marker)
                    return true;

                // check for vertical values
                if (topLeft == marker && centerLeft == marker && bottomLeft == marker)
                    return true;
                if (topCenter == marker && datCenter == marker && bottomCenter == marker)
                    return true;
                if (topRight == marker && centerRight == marker && bottomRight == marker)
                    return true;

                // check for diagonal values
                if (topLeft == marker && datCenter == marker && bottomRight == marker)
                    return true;
                if (topRight == marker && datCenter == marker && bottomLeft == marker)
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error trying to check for win: {e.Message}.");
                return false;
            }
            return false;
        }
    }
}
