using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GetBit_Project
{
    class CharacterAI : Player
    {
        static public Random rand = new Random();

        public CharacterAI(Graphics paper,string faction, int health=100)
            : base(paper, faction, health)
        {

        }

        public override void PlayCard()
        {
            
            ChooseCard(Cardset[rand.Next(Cardset.Count)]);
            // draw card
        }

        public override void Update()
        {
            // restore graveyard if hand low
            if (this.Cardset.Count <= 2)
            {
                this.RestoreGraveyard();
            }
        }
    }
}
