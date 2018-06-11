using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_Tic_Tac_Toe.Classes
{
    /// <summary>
    /// class that handles the attributes for each player
    /// </summary>
    class Player
    {
        public string Name { get; set; }
        public string Marker { get; set; }
        public bool IsActive { get; set; }
        public Player(string name, string marker, bool active)
        {
            Name = name;
            Marker = marker;
            IsActive = active;
        }

        /// <summary>
        /// method to switch out players
        /// </summary>
        /// <param name="playerActiveStatus"></param>
        /// <returns></returns>
        public bool ChangePlayer(bool playerActiveStatus)
        {
            try
            {
                if (playerActiveStatus == true)
                    return false;
                else
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error switching players: {e.Message}.");
            }
            return false;
        }
    }
}
