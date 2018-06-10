using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_Tic_Tac_Toe.Classes
{
    class GameBoard
    {
        public string[][] Layout { get; set; }

        public GameBoard(string[][] currentSetup)
        {
            Layout = currentSetup;
        }
    }
}
