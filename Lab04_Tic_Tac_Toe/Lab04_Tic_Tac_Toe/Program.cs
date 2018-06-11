using Lab04_Tic_Tac_Toe.Classes;
using System;

namespace Lab04_Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;

            Console.WriteLine("Welcome to Lab 04: Tic-Tac-Toe!\n");
            while (runProgram == true)
            {
                bool player1Win = false;
                bool player2Win = false;

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
                Console.WriteLine($"Ready...FIGHT!\n");

                GameBoard datGameBoard = new GameBoard();
                bool player1Turn = true;
                bool player2True = false;
                bool takingTurns = true;
                while (takingTurns = true)
                {
                    datGameBoard.DisplayBoard(datGameBoard.Layout);
                    Console.WriteLine("Choose a number.");
                    string chosenNum = Console.ReadLine();
                    if (player1Turn == true)
                        datGameBoard.Layout = datGameBoard.UpdateBoard(chosenNum, datGameBoard.Layout, player1.Marker);
                    else
                        datGameBoard.Layout = datGameBoard.UpdateBoard(chosenNum, datGameBoard.Layout, player2.Marker);
                }
                datGameBoard.DisplayBoard(datGameBoard.Layout);

                Console.ReadLine();
                if (player1Win == false && player2Win == false)
                {
                    Console.WriteLine("It's a draw!");
                }

                Console.WriteLine("Game over! Play again?");
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
                }
                else
                    runProgram = false;
            }

            Console.WriteLine("Thank you for playing! Press any button to exit.");
            Console.ReadLine();
        }

    }
}
