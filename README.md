# Get-Bit-Card-Game - C# based App

Rules of the game: https://boardgamegeek.com/boardgame/30539/get-bit

![main screen](https://github.com/aza0092/Get-Bit-Card-Game/blob/master/GetBit%20Project/media/mainScreen.jpg)

## Description

The Get Bit! card game is a survival game. Players are placed on orders based on drawn cards, and the player who is in the last order get bitten by the shark and loses a limb and then is placed in front of the line. Players who eventually lose all their limbs die. The player who has the most limbs after there is only two players wins the game.

Before the start of the game, the player can set the bot difficulty (easy - meduim - hard). The game also keeps track of each player's health, position, and card color (Blue - Yellow - Green - Gray).

## Technical 
- `adapters` folder contains adapters for: database - directions - ingredients - main page - recipes - viewPager for a single recipe (Ingrediants, Directions). 
- `dao` folder contains data access objects for: directions - ingredients - SQLiteDatabaseHelper - recipes - users (id, password, name, email). 
- `models` folder contains classes to define a: database - direction - ingredient - recipe - user.
- `ui` folder contains the fragments for the different cuisines and the activities.
- `utils` folder contains snippets of code for various functionalities.

## Images
| ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/splash%20screen.png) | ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/main%20screen.png) |
|:---:|:---:|
| The splash screen  | main screen when the app is first opened |

| ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/invalid%20credentials.png) | ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/new%20acc.png) |
|:---:|:---:|
| The app has functionality to check for invalid credentials | Create new account screen |

| ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/recipes.png) |
|:---:|
| Recipes are divided into 5 cuisines: American - Vegan - Asian - Mediterrean - European | 

| ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/add%20new%20rcipe%20or%20sign%20out.png) | ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/edit-delete.png) |
|:---:|:---:|
| The vertical ellipsis icon allows option to create new recipe/sign out | Edit or delete a single recipe |

| ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/edit%20rec.png) | ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/edit%20ing%20or%20add%20new.png) | ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/edit%20new%20descr.png) |
|:---:|:---:|:---:|
| Edit an existent recipe pages 1| Edit an existent recipe pages 2| Edit an existent recipe pages 3|

| ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/new%20recipe%20new%20descri%20plus%20image.png) | ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/new%20rec%20added.png) | ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/new%20rec%20dir.png) |
|:---:|:---:|:---:|
| Add new recipe| New recipe ingredients| New recipe directions|

| ![](https://github.com/aza0092/Cooking-Recipe-Android-App/blob/master/media/material%20design.gif) |
|:---:|
| Material Design motions |
