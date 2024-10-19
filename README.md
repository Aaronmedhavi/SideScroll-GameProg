## ⚔️ About
A Warriors Journey is an exciting 2D sidescroller game developed using the Unity game engine. Embark on an adventure through beautifully crafted levels, overcome challenges, and defeat enemies as you progress through the game.

## 🕹️ Option 1: Download from GitHub Releases

1. Go to
   ```
   https://github.com/Aaronmedhavi/SideScroll-GameProg/releases/tag/v0.3.0-alpha
   ```
2. Download the latest release.
3. Extract the downloaded archive.
4. Run the game executable.

## 📁 Option 2: Clone the Repository

1. Make sure you have Unity (version 2022.3.9f1 or later) installed on your machine.
2. Clone this repository:
   ```
   git clone https://github.com/Aaronmedhavi/SideScroll-GameProg.git
   ```
3. Open the project in Unity.
4. Open the "MainMenu" scene located in the "Assets/Scenes" folder.
5. Press the Play button in Unity Editor to start the game.

## 🎮 Controls

- Move: A/D
- Jump: Spacebar
- Attack: Left Mouse Button
- Pause: Escape
- Reset Progress(In main menu) Ctrl + R

## 📺 Gameplay Footage / Screenshot

## ⚙️ Mechanics
<h3>Netcode For GameObjects</h3>
<p align="justify">Experience online multiplayer experience made possible with Netcode. Through the use of a network manager, it allows players to join the game as a host or a client in a menu. The game will start when there is 2 players in the game, the ball will spawn once all the players have joined. The built in network manager only provide one slot for the player prefab but with the use of an index based on the client ID, it's now possible for players to play with distinct sprites.</p>

<h3>Post Processing</h3>
<p align="justify">Implementation of basic post processing which includes bloom and color grading to increase visual fidelity and enhance the player experience without sacrificing any performance.</p>

## 📚 Features and Script
- Engaging 2D sidescroller gameplay
- Multiple levels with increasing difficulty
- Stunning visuals and immersive soundtrack
- Smooth character animations and responsive controls

|  Script       | Description                                                  |
| ------------------- | ------------------------------------------------------------ |
| `UIMenu.cs` | Manages the UI elements in the main menu. |
| `AudioManager.cs` | Manages all sounds in the game including sound effects and BGM. |
| `GameManager.cs`  | Manages the saving and loading save file and resetting the level progress. |
| `PlayerMovement.cs`  | Handle the player movement and animaation ensuring smooth gameplay. |
| `etc`  | |
