## ⚔️ About
A Warriors Journey is an exciting 2D sidescroller game developed using the Unity game engine. Embark on an adventure through beautifully crafted levels, overcome challenges, and defeat enemies as you progress through the game.

## Project Info
| **Role** | **Team Size** | **Development Time** |
|----------|---------------|---------------------|
| Game Programmer | 1 | 1 Week |

| **Name** | **Role** |
|----------|----------|
| Aaron Medhavi Kusnandar | Game Programmer |

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
Saving system in this game is handled using JSON, it allows players to save their progress and load their latest progress. Players can also reset their level progress in order to try and get a better time for their levels.

### Enemy Cannon
Enemy cannon is controlled by a script that detects the player within a certain range and fires projectiles at them. Projectiles which is a fireball prefab that are instantiated by a point within the cannon sprite and will damage the player upon impact.

### Level Design
Level design is made by utilizing a tilemap that allows for more precise placement of the ground. Parallax is also used for the background to create a smooth and seamless background movement.

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

## 🕹️ Installation

1. Go to
   ```
   https://aaronmedhavi.itch.io/a-warriors-journey
   ```
2. Download the latest release.
3. Extract the downloaded archive.
4. Run the game executable.

## 📫 Contact
If you want to provide feedback or report bugs, feel free to reach out to me here:
- Email: aaronmedhavi@gmail.com
