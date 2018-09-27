using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GetBit_Project
{
    class MediumCharacterAI : CharacterAI
    {
        public MediumCharacterAI(Graphics paper, string faction, int health = 100)
            : base(paper, faction, health)
        {
        }

        public override void PlayCard()
        {
            ChooseCard(Cardset[rand.Next(3, Cardset.Count)]);
        }
    }
}
