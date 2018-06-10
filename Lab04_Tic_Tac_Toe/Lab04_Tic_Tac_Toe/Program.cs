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
                Player player1 = new Player(player1Name);

                Console.WriteLine("Player 2, please enter your name:");
                string player2Name = Console.ReadLine();
                while (player2Name == "")
                {
                    Console.WriteLine("Please enter SOMETHING for a name.");
                    player2Name = Console.ReadLine();
                }
                Player player2 = new Player(player2Name);

                Console.WriteLine($"Welcome, {player1.Name} and {player2.Name}.");

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
