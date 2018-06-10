using System;

namespace Lab04_Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;
            while (runProgram == true)
            {
                Console.WriteLine("run game stuff here");
                Console.WriteLine("Game over! Play again?");
                string playAgain = Console.ReadLine().ToLower();
                while (playAgain != "y" && playAgain != "yes" && playAgain != "n" && playAgain != "no")
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    playAgain = Console.ReadLine().ToLower();
                }

                if (playAgain == "y" || playAgain == "yes")
                    Console.Clear();
                else
                    runProgram = false;
            }

            Console.WriteLine("Thank you for playing! Press any button to exit.");
            Console.ReadLine();
        }
    }
}
