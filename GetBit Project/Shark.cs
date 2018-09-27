using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetBit_Project
{
    class Shark : Unit
    {
        /// <summary>
        /// Damage the player health
        /// </summary>
        /// <param name="player">the player's health which will be damaged (last position)</param>
        public static void Eat(Player player)
        {
            
            player.Health-=34;
        }
    }
}
