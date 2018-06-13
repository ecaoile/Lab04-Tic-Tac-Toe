using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_Tic_Tac_Toe.Classes
{
    /// <summary>
    /// class that creates a game board and handles game board changes
    /// </summary>
    public class GameBoard
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

        public GameBoard(string[][] testLayout)
        {
            Layout = testLayout;
            Taken = defaultTaken;
        }

        /// <summary>
        ///  Displays the board to the console
        /// </summary>
        /// <param name="datBoard">string array of values to display</param>
        /// <returns>true value confirming whether the board was successfully displayed</returns>
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

        /// <summary>
        /// method that begins the game after users have entered their names
        /// </summary>
        /// <param name="datGameBoard">the game board object of GameBoard class</param>
        /// <param name="player1">first player object of Player class</param>
        /// <param name="player2">second player object of Player class</param>
        public void PlayGame(GameBoard datGameBoard, Player player1, Player player2)
        {
            bool player1Win = false;
            bool player2Win = false;
            bool takingTurns = true;
            int turn = 1;
            // inner loop for alternating turns once users have entered names and game starts
            while (takingTurns == true)
            {
                Console.WriteLine();
                DisplayBoard(datGameBoard.Layout);
                if (player1.IsActive == true)
                    Console.WriteLine($"{player1.Name}'s turn ({player1.Marker}).");
                else
                    Console.WriteLine($"{player2.Name}'s turn ({player2.Marker}).");

                Console.WriteLine("Choose a number.");
                string chosenNum = Console.ReadLine();
                VerifyNum(chosenNum);

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

                if (player1.IsActive == true)
                {
                    datGameBoard.Layout = datGameBoard.UpdateBoard(chosenNum, datGameBoard.Layout, player1.Marker);
                    player1Win = CheckForWin(datGameBoard.Layout, player1.Marker);
                }
                else
                {
                    datGameBoard.Layout = datGameBoard.UpdateBoard(chosenNum, datGameBoard.Layout, player2.Marker);
                    player2Win = CheckForWin(datGameBoard.Layout, player2.Marker);
                }

                if (player1Win == true || player2Win == true)
                    takingTurns = false;
                if (turn == 9)
                    takingTurns = false;
                turn++;
                player1.IsActive = player1.ChangePlayer(player1.IsActive);
                player2.IsActive = player2.ChangePlayer(player2.IsActive);
            }

            if (player1Win == true)
                Console.WriteLine($"{player1.Name} wins!");
            if (player2Win == true)
                Console.WriteLine($"{player2.Name} wins!");

            if (player1Win == false && player2Win == false)
            {
                Console.WriteLine("It's a draw!");
            }
        }

        /// <summary>
        /// post game message that gives users the option to play another game or exit the program
        /// </summary>
        /// <returns>boolean value that decides whether the program exits the while loop</returns>
        public bool PostGame()
        {
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
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// method that verifies the entered number is an integer from 1 to 9
        /// </summary>
        /// <param name="chosenNum">user input</param>
        public static void VerifyNum(string chosenNum)
        {
            bool isNumeric = int.TryParse(chosenNum, out int chosenNumIntForm);
            while (isNumeric == false || chosenNumIntForm > 9 || chosenNumIntForm < 1)
            {
                Console.WriteLine();
                if (isNumeric == false)
                    Console.WriteLine("That was not a valid integer. Please try again.");
                if (chosenNumIntForm > 9 || chosenNumIntForm < 1)
                    Console.WriteLine("Pick one of the numbers on the board.");
                chosenNum = Console.ReadLine();
                isNumeric = int.TryParse(chosenNum, out chosenNumIntForm);
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
                // assigning board values string names for easier understanding
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
