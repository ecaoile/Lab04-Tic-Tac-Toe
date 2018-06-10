﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_Tic_Tac_Toe.Classes
{
    class Player
    {
        public string Name { get; set; }
        public char Marker { get; set; }

        public Player(string name, char marker)
        {
            Name = name;
            Marker = marker;
        }

    }
}
