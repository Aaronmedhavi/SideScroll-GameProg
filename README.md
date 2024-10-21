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

## 🎮 Controls

- Move: A/D
- Jump: Spacebar
- Attack: Left Mouse Button
- Pause: Escape
- Reset Progress(In main menu) Ctrl + R

## 📺 Gameplay Footage / Screenshot
  <tr>
    <td><img src="https://github.com/Aaronmedhavi/SideScroll-GameProg/blob/main/side - Made with Clipchamp.gif?raw=true" width="500"></td>
  </tr>
<table>
  <tr>
    <td><img src="https://github.com/Aaronmedhavi/ProjectClips/blob/main/Screenshot 2024-10-20 235207.png?raw=true" width="400"></td>
    <td><img src="https://github.com/Aaronmedhavi/ProjectClips/blob/main/Screenshot 2024-10-20 235032.png" width="400"></td>
  </tr>
</table>

## ⚙️ Mechanics

### Saving System
Experience online multiplayer experience made possible with Netcode. Through the use of a network manager, it allows players to join the game as a host or a client in a menu. The game will start when there is 2 players in the game, the ball will spawn once all the players have joined. The built in network manager only provide one slot for the player prefab but with the use of an index based on the client ID, it's now possible for players to play with distinct sprites.

### Enemy Cannon
Implementation of basic post processing which includes bloom and color grading to increase visual fidelity and enhance the player experience without sacrificing any performance.

### Level Design

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
