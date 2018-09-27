using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GetBit_Project
{
    class DifficultCharacterAI : CharacterAI
    {
        public DifficultCharacterAI(Graphics paper, string faction, int health = 100)
            : base(paper, faction, health)
        {
        }

        public override void PlayCard()
        {

            List<Card> cardset = new List<Card>() { new Card(6, this), new Card(7, this) };
            ChooseCard(cardset[rand.Next(0, cardset.Count)]);
        }
    }
}
