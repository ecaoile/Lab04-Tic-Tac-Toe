using Lab04_Tic_Tac_Toe.Classes;
using System;

namespace Lab04_Tic_Tac_Toe
{
    public class Program
    {
        /// <summary>
        /// main entry point to the lab: opens up the game console and starts a tic-tac-toe game
        /// </summary>
        /// <param name="args">some stuff needed to run a main method...</param>
        static void Main(string[] args)
        {
            RunProg();
            Console.WriteLine("Thank you for playing! Press any button to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// method that runs the game
        /// </summary>
        public  static void RunProg()
        {
            bool runProgram = true;

            Console.WriteLine("Welcome to Lab 04: Tic-Tac-Toe!\n");
            // outer loop for main program
            while (runProgram == true)
            {
                Console.WriteLine("Player 1, please enter your name:");
                string player1Name = Console.ReadLine();
                while (player1Name == "")
                {
                    Console.WriteLine("Please enter SOMETHING for a name.");
                    player1Name = Console.ReadLine();
                }
                Player player1 = new Player(player1Name, "X", true);

                Console.WriteLine("Player 2, please enter your name:");
                string player2Name = Console.ReadLine();
                while (player2Name == "")
                {
                    Console.WriteLine("Please enter SOMETHING for a name.");
                    player2Name = Console.ReadLine();
                }
                Player player2 = new Player(player2Name, "O", false);

                Console.Clear();
                Console.WriteLine($"Welcome, {player1.Name} and {player2.Name}.");
                Console.WriteLine($"{player1.Name}'s marker: {player1.Marker}.");
                Console.WriteLine($"{player2.Name}'s marker: {player2.Marker}.");
                Console.WriteLine($"Ready...FIGHT!");
                GameBoard datGameBoard = new GameBoard();

                datGameBoard.PlayGame(datGameBoard, player1, player2);
                runProgram = datGameBoard.PostGame();
            }
        }
    }
}
