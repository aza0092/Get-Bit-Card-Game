using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using System.Drawing;

namespace GetBit_Project
{
    class Card : Unit, IComparable
    {
        private int value;

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private Player player;

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public Card(int value, Player p)
        {
            this.Value = value;
            this.player = p;
            GetSprite(); // gets the card's sprite
        }

        /// <summary>
        /// compare two cards values 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>fals if card value is null, or true if card have the same values</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Card card = obj as Card;
            if ((System.Object)card == null)
            {
                return false;
            }

            return (this.Value == card.Value); // return true if the two crads are equal
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator ==(Card card1, Card card2)
        {
            if (System.Object.ReferenceEquals(card1,card2))
            {
                return true;
            }
            if (((object)card1 == null || (object)card2 == null))
            {
                return false;
            }
            // check if two cards are equal
            return (card1.Value == card2.Value);
        }


        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }

        public int CompareTo (object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Card card1 = obj as Card;
            if (card1 == null)
            {
                throw new ArgumentException("Another card is required for comparision.", "obj");
            }
                            
            return this.CompareTo(card1);
        }

                
        public int CompareTo (Card obj)
        {
            if(object.ReferenceEquals(obj, null))
            {
                return -1;
            }
            else if (obj.Value > this.Value)
            {
                return -1;
            }
            else if (obj.Value < this.Value)
            {
                return 1;
            }
            return 0;
        }

        public static int Compare(Card card1, Card card2)
        {
            if (object.ReferenceEquals(card1,card2))
            {
                return 0;
            }
            if (object.ReferenceEquals(card1,null))
            {
                return -1;
            }
            return card1.CompareTo(card2);
        }
        public static bool operator < (Card card1,Card card2)
        {
            return (Compare(card1, card2) < 0);
        }

        public static bool operator > (Card card1, Card card2)
        {
            return (Compare(card1, card2) > 0);
        }

        public override void GetSprite()
        {
            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file;
            String s = String.Format("GetBit_Project.Resources.{0}{1}.png", this.Player.Faction, this.value);
            file = thisExe.GetManifestResourceStream(s);
            this.Sprite = new Bitmap(file);
        }

        public override void Render(Graphics paper)
        {
            paper.DrawImage(Sprite,new Point(0,0));
            
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
