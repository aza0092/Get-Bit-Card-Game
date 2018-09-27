using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace GetBit_Project
{
    class Unit : IGameObject
    {
        private int position;

        public int Position
        {
            get { return position; }
            set { position = value; }
        }
        private string faction; //color of cards

        public string Faction
        {
            get { return faction; }
            set { faction = value; }
        }
        private Bitmap sprite;

        public Bitmap Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        private int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public virtual void GetSprite()
        {
            System.Reflection.Assembly thisExe;
            thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            System.IO.Stream file;
            String s = String.Format("GetBit_Project.Resources.{0}Player{1}.jpg", this.Faction, this.Health.ToString());
            file = thisExe.GetManifestResourceStream(s);
            this.Sprite = new Bitmap(file);

        }

        public override void Render(Graphics paper)
        {
            paper.DrawImage(this.Sprite, new Point(0,0));
        }

        public virtual void PlayCard()
        {
            throw new NotImplementedException();
        }
    }
}
