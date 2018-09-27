using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetBit_Project
{
    /// <summary>
    /// This is a class to hold the information for the players in the game
    /// </summary>
    class Player : Unit
    {
        /// <summary>
        /// A listBox of pictureboxes to store the pictureboxes used for the player's cardset
        /// </summary>
        private List<PictureBox> hand;

        public List<PictureBox> Hand
        {
            get { return hand; }
            set { hand = value; }
        }
        /// <summary>
        /// The player's hand
        /// </summary>
        private List<Card> cardset;

        /// <summary>
        /// Value to store the position of the last played card
        /// </summary>
        private Card lastPlayedCard;

        /// <summary>
        /// Value to deposit the cardset when it's less than 2 cards
        /// </summary>
        private Graphics cardsDeposit;

        public Graphics CardsDeposit
        {
            get { return cardsDeposit; }
            set { cardsDeposit = value; }
        }

        public Card LastPlayedCard
        {
            get { return lastPlayedCard; }
            set { lastPlayedCard = value; }
        }

        /// <summary>
        /// // the cards the player has played
        /// </summary>
        private List<Card> graveyard;

        public List<Card> Graveyard
        {
            get { return graveyard; }
            set { graveyard = value; }
        }
        public List<Card> Cardset
        {
            get { return cardset; }
            set { cardset = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paper">Cardset of player</param>
        /// <param name="faction">Pplayer group (gree,grey,yellow,blue)</param>
        /// <param name="health">Player's health is set to 100</param>
        public Player(Graphics paper, string faction, int health = 100)
        {
            this.Health = health;
            this.Faction = faction;
            this.cardset = new List<Card>();
            this.Graveyard = new List<Card>();
            this.CardsDeposit = paper;
            this.GetSprite(); //get the player sprite
        }

        /// <summary>
        /// Choose card will find and remove card
        /// from the Players card set and place it
        /// into the player's graveyard
        /// </summary>
        /// <param name="card">player's card played</param>
        public void ChooseCard(Card card)
        {
            this.Cardset.Remove(card); //we ned to remove the card from the cardsset picturebox to display it to the cards being played picturebox
            Graveyard.Add(card); //graveyard list to hold the played cards, and restore it when cardsset is less than 2
            this.LastPlayedCard = card;
            card.Render(CardsDeposit); //draw the card on the picturebox
            this.Update(); 
        }

        /// <summary>
        /// Method to call when cardsset is less than 2
        /// </summary>
        public void RestoreGraveyard()
        {
            cardset.AddRange(graveyard);
            List<Card> clone = cardset;
            cardset = clone.OrderBy(x=>x.Value).ToList(); //clone the cards by order
            graveyard = new List<Card>(); 
            
        }

        /// <summary>
        /// Update the game after each round
        /// </summary>
        public override void Update()
        {
            // restore graveyard if hand low
            if (cardset.Count <= 2)
            {
                this.RestoreGraveyard();
                DrawCards();
                
            }


        }

        public override void GetSprite()
        {
            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file;
            int health = 100;
            if (this.Health > 70)
            {
                health = 100;
            }
            else if (this.Health > 40 && this.Health < 70)
            {
                health = 66;
            }
            else 
            {
                health = 34;
            }
            String s = String.Format("GetBit_Project.Resources.{0}Player{1}.jpg", this.Faction, health);
            file = thisExe.GetManifestResourceStream(s);
            this.Sprite = new Bitmap(file);

        }

        /// <summary>
        /// Drawing the cards on the form
        /// </summary>
        public void DrawCards()
        {
                for (int i = 0; i < this.Cardset.Count; i++)
                {
                    this.Cardset[i].Render(hand[i].CreateGraphics());
                    hand[i].Text = String.Format("{0}{1}", this.Faction, (i + 1.ToString()));
                }
        }

        /// <summary>
        /// Restores players graveyard;
        /// edraws the character's hand
        /// updates position of character
        /// reobtains player's sprite in case of limb difference
        /// </summary>
        public void CheckEaten()
        {
            
            RestoreGraveyard();
            if (!(this is CharacterAI))
            {
                DrawCards();
            }
            // consume player
            Shark.Eat(this);
            this.GetSprite();
            // update position to front position instead of rear
            this.Position = 3;
        }

        public override string ToString()
        {
            return Faction;
        }
    }
}
