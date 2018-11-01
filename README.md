# Get-Bit-Card-Game - C# based Game

Rules of the game: https://boardgamegeek.com/boardgame/30539/get-bit

![main screen](https://github.com/aza0092/Get-Bit-Card-Game/blob/master/GetBit%20Project/media/mainScreen.jpg)

## Description

The Get Bit! card game is a survival game. Players are placed on orders based on drawn cards, and the player who is in the last order get bitten by the shark and loses a limb and then is placed in front of the line. Players who eventually lose all their limbs die. The player who has the most limbs (highest health) after there is only two players is the winner of the game.

Before the start of the game, the player can set the bot difficulty (easy - meduim - hard). The game also keeps track of each player's health, position, and card color (Blue - Yellow - Green - Gray). Also, players can check instructions from the help dropdown menu.

## Technical 
- `Card` stores the value (health) of the card which is linked to a player. 
- `CharacterAI` makes an abstraction for new AI player for the game.
- `DifficultCharacterAI` creates a new AI player for the game with a hard difficulty. This puts the human player in the last position in the first round to put them at a disadvantage health-wise.
- `MediumCharacterAI` creates a new AI player for the game with a meduim difficulty. This puts the human player 3 positions behind in the first round to put them at a disadvantage health-wise.
- `EasyCharacterAI` creates a new AI player for the game with an easy difficulty. This puts the human player at any position randomly without a disadvantage health-wise.
- `Form1` draws the template of the game and includes the main functionalities (update health, change positions, check last position, move players, draw cards, indicate a dead player).- `Form1` draws the template of the game and includes the main functionalities (update health, change positions, check last position, move players, draw cards, indicate a dead player).
- `Form2` used to start a new game when the initial game ends.
- `IGameObject` used to link graphics to the card face.
- `Player` used to hold info for the human player (health, position, card chosen, check death).
- `Shark` used to damage the player's health when they are in the last position of the card set.
- `Unit` used to link cards' colors.


## Images
| ![](https://github.com/aza0092/Get-Bit-Card-Game/blob/master/GetBit%20Project/media/startGame.png) | ![](https://github.com/aza0092/Get-Bit-Card-Game/blob/master/GetBit%20Project/media/botDifficulty.png) |
|:---:|:---:|
| Start Game  | Bot difficulty Options |



| ![](https://github.com/aza0092/Get-Bit-Card-Game/blob/master/GetBit%20Project/media/cardColors.png) | ![](https://github.com/aza0092/Get-Bit-Card-Game/blob/master/GetBit%20Project/media/cardSets.PNG) |
|:---:|:---:|
| Colors of cards in the game and the shark | Card sets options to choose from each round(1-7) |



| ![](https://github.com/aza0092/Get-Bit-Card-Game/blob/master/GetBit%20Project/media/health.PNG) | ![](https://github.com/aza0092/Get-Bit-Card-Game/blob/master/GetBit%20Project/media/status.PNG) |
|:---:|:---:|
| Players' heatlh updates after every round | Players' statuses updates after every round |



| ![](https://github.com/aza0092/Get-Bit-Card-Game/blob/master/GetBit%20Project/media/limbs.PNG) | ![](https://github.com/aza0092/Get-Bit-Card-Game/blob/master/GetBit%20Project/media/dead.PNG) |
|:---:|:---:|
| players losing limb when getting in last position | player who lost all their limb no longer in the game (card removed ) |



| ![](https://github.com/aza0092/Get-Bit-Card-Game/blob/master/GetBit%20Project/media/healthDead.png) | ![](https://github.com/aza0092/Get-Bit-Card-Game/blob/master/GetBit%20Project/media/winner.png) |
|:---:|:---:|
| dead player indicated | winner annoucned at end of game |
