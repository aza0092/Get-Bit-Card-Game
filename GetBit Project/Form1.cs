using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//ToDo: when player is damaged, move to first position

namespace GetBit_Project
{
    public partial class Form1 : Form
    {
        static List<PictureBox> _playerHand;
        List<PictureBox> _positions;
        // variables
        List<Player> _players;
        Player _mainPlayer;
        List<string> _factions = new List<string> { "Green", "Grey", "Yellow", "Blue" };
        const int _maxCards = 7;
        bool gameRunning = false;
        Dictionary<Player, Card> playerCard;
        List<PictureBox> playedCardsPicturBox;
        bool _firstRound = true;
        string botDifficulty = "easy"; 
        List<KeyValuePair<Player, Card>> positionOfPlayers;

        public Form1()
        {
            InitializeComponent();
            _playerHand = new List<PictureBox>(){playerCard0,playerCard1,playerCard2,playerCard3,playerCard4,
                                                                     playerCard5,playerCard6};

            playedCardsPicturBox = new List<PictureBox>() { card0PictureBox, card1PictureBox, card2PictureBox, card3PictureBox };
        }


        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitiateGame();
        }

        private void InitiateGame()
        {

            foreach (PictureBox p in playedCardsPicturBox)
            {
                p.Refresh();
            }
            // instantiate variables
            _players = new List<Player>();
            playerCard = new Dictionary<Player, Card>();

            DealCards();

            _mainPlayer = _players.Find(x => x.Faction == "Green");
            _mainPlayer.Hand = _playerHand;
            _mainPlayer.DrawCards();
            gameRunning = true;

            DrawPlayers();

            DrawShark();
            UpdateHealthMeters();
            // update textbox
            SwimmersPositionTextBox.Clear();
        }

        private void DealCards()
        {
            for (int f = 0; f < _factions.Count; f++)
            {
                if (_factions[f] == "Green")
                {
                    FillPlayerHand(new Player(card0PictureBox.CreateGraphics(), _factions[f]));
                }
                else
                {
                    // decide on bot difficulty here
                    switch (botDifficulty)
                    {
                        case "easy":
                            FillPlayerHand(new EasyCharacterAI(playedCardsPicturBox[f].CreateGraphics(), _factions[f]));
                            break;
                        case "medium":
                            FillPlayerHand(new ModerateCharacterAI(playedCardsPicturBox[f].CreateGraphics(), _factions[f]));
                            break;
                        case "hard":
                            FillPlayerHand(new DifficultCharacterAI(playedCardsPicturBox[f].CreateGraphics(), _factions[f]));
                            break;

                    }
                }
            }
        }

        private void DrawPlayers()
        {
            // store picture boxes for drawing toys in
            _positions = new List<PictureBox>() { positionOnePictureBox, positionTwoPictureBox, positionThreePictureBox, positionFourPictureBox };
            // draw toys
            for (int i = 0; i < _positions.Count; i++)
            {
                _positions[i].Image = _players[i].Sprite;
            }
        }


        private void FillPlayerHand(Player player)
        {
            for (int i = 1; i <= _maxCards; i++)
            {
                // create a card
                Card c = new Card(i, player);
                player.Cardset.Add(c);
            }
            _players.Add(player);
        }

        private void checkPosition()
        {
            string textBoxOutput="";
            foreach (Player p in _players)
            {
                if (playerCard.ContainsKey(p))
                {
                    playerCard[p] = p.LastPlayedCard;
                }
                else
                {
                    playerCard.Add(p, p.LastPlayedCard);
                }
            }
            positionOfPlayers = playerCard.OrderBy(key => key.Value).ToList();
            // omnomnom player in last place
            string s = CheckChowder(positionOfPlayers[0].Key);
            // taken from http://stackoverflow.com/questions/289/how-do-you-sort-a-dictionary-by-value
            for (int i = positionOfPlayers.Count-1; i >= 0; i--) //sort by card value
            {
                positionOfPlayers[i].Key.Position = i;
                positionOfPlayers[i].Key.Update();
                positionOfPlayers[i].Key.Render(_positions[i].CreateGraphics());
                _positions[i].Image = positionOfPlayers[i].Key.Sprite;
                this.Invalidate();
                textBoxOutput += "Player: " + positionOfPlayers[i].Key.ToString() + " with health " + positionOfPlayers[i].Key.Health.ToString() + " played card with value " + positionOfPlayers[i].Value.ToString() + " now at position: " + (positionOfPlayers.Count-i).ToString() + Environment.NewLine;
                
            }
            SwimmersPositionTextBox.Text = textBoxOutput + s + Environment.NewLine;
            // udpate HP to match round
            UpdateHealthMeters();
            // if dead player remove from game
            RemoveTheDead(positionOfPlayers);
            if (_players.Count == 2)
            {
                // clear shark and unwanted player
                //positionTwoPictureBox.Image = null;
                //SharkPictureBox.Image = null;

                // swap the images
                Image img = positionTwoPictureBox.Image;
                positionTwoPictureBox.Image = positionOnePictureBox.Image;
                positionOnePictureBox.Image = img;

                MessageBox.Show("Congratulations " + positionOfPlayers[1].Key.ToString() + ", you've won!");
                

                gameRunning = false;
            }

            
        }

        private void UpdateHealthMeters()
        {
            player1HealthTextBox.Text = _players[0].Health.ToString();
            player2HealthTextBox.Text = _players.Count >= 2 ? _players[1].Health.ToString() : "Dead.";
            player3HealthTextBox.Text = _players.Count >= 3 ? _players[2].Health.ToString() : "Dead.";
            player4HealthTextBox.Text = _players.Count >= 4 ? _players[3].Health.ToString() : "Dead.";
        }

        private void RemoveTheDead(List<KeyValuePair<Player, Card>> positionOfPlayers)
        {
            int last = positionOfPlayers.Count-1;
            if (positionOfPlayers[last].Key.Health <= 0)
            {
                KeyValuePair<Player, Card> remove = positionOfPlayers[last];
                positionOfPlayers.Remove(remove);
                
                Player p = remove.Key;
                _players.Remove(p);
                playerCard.Remove(p);
                // set picture box at zeroth position to hold winner of the round
                Image survivor = positionOnePictureBox.Image;

                MovePlayersPositions(_players.Count);
               
                _positions[_players.Count-1].Image = survivor;
                // remove the loser
                _positions[_players.Count].Image = null;
            }
        }

        private void MovePlayersPositions(int j)
        {

            for (int i = 0; i < j; i++)
            {
                _positions[i].Image = _positions[i + 1].Image;
            }
        }

        private bool GameRunning()
        {
            if (!gameRunning)
            {
                MessageBox.Show("Game not running yet!", "GetBit Project", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }


        private void DrawShark()
        {
            if (!GameRunning())
            {
                return;
            }
            SharkPictureBox.Image = GetBit_Project.Properties.Resources.shark;
        }


        private void PlayCard(PictureBox sender, int value)
        {
            if (!GameRunning())
            {
                return;
            }
            if (sender.Text == "Blank")
            {

                MessageBox.Show("This is an empty card.");
            }
            else
            {
                if (_mainPlayer.Health > 0)
                {
                    Card c = _mainPlayer.Cardset.Find(x => x.Value == value);
                    sender.Text = "Blank";
                    sender.CreateGraphics().Clear(Color.Wheat);
                    _mainPlayer.ChooseCard(c);
                }                 
                foreach (Player p in _players)
                {
                    if (p is CharacterAI)
                    {
                        CharacterAI cai = (CharacterAI)p;
                        cai.PlayCard();
                    }
                }
                // check cards
                checkPosition();
            }
        }

        /// <summary>
        /// check to see if current position of card is last
        /// gets eaten
        /// </summary>
        private string CheckChowder(Player player)
        {  // move player in last place to first place
            if (!_firstRound)
            {
                player.CheckEaten();
                // create temp variable for imaghe
                //Image tempImage = positionOnePictureBox.Image;
                // move rest of players
                //MovePlayersPositions(_players.Count - 1);
                // place temp image into front picturebox
                //positionFourPictureBox.Image = tempImage;
                // store player in last place in temp variable
                KeyValuePair<Player, Card> temp = positionOfPlayers[0];
                // remove player from positionOfPlayers
                positionOfPlayers.Remove(temp);
                // add player to the end of positionOfPlayers
                positionOfPlayers.Add(temp);
                return Environment.NewLine + player.ToString() + " lost a chunck!";
            }
            _firstRound = false;
            return Environment.NewLine +  "Careful " + player.ToString() + ", you don't want to lose a limb!";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Copyright © 2014 Abdullah Alali. All Rights Reserved.", "GetBit Project", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void instructionsOnHowToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //taken from http://boardgamegeek.com/boardgame/30539/get-bit
            MessageBox.Show("You don't have to be faster than the shark, just faster than your friends!" + "\r\n" + "\r\n" + "Get Bit! is a card game where players are competing to stay alive as the others are being eaten by the shark." + "\r\n" + "\r\n" + "The order of the swimmers is determined by simultaneously playing cards face-down then revealing the values. The number on each player's card determines position in line (higher numbers in front, lower numbers in back), however ties don't move. The swimmer at the back loses a limb to the shark and is flung to the front of the line! The process is repeated until only two swimmers remain on the table. When this happens, the swimmer at the front of the line wins the game!", "GetBit Project", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void playerCard0_Click_1(object sender, EventArgs e)
        {
            PlayCard(playerCard0, 1);
        }

        private void playerCard1_Click_1(object sender, EventArgs e)
        {
            PlayCard(playerCard1, 2);
        }

        private void playerCard2_Click_1(object sender, EventArgs e)
        {
            PlayCard(playerCard2, 3);
        }

        private void playerCard3_Click_1(object sender, EventArgs e)
        {
            PlayCard(playerCard3, 4);
        }

        private void playerCard4_Click_1(object sender, EventArgs e)
        {
            PlayCard(playerCard4, 5);
        }

        private void playerCard5_Click_1(object sender, EventArgs e)
        {
            PlayCard(playerCard5, 6);
        }

        private void playerCard6_Click_1(object sender, EventArgs e)
        {
            PlayCard(playerCard6, 7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!GameRunning())
            {
                return;
            }
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!GameRunning())
            {
                return;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
                Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botDifficulty = "easy";
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botDifficulty = "medium";
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            botDifficulty = "hard";
        }
    }
}
