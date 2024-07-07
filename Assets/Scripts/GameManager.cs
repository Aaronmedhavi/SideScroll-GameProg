using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isPaused;
    public bool isStart;
    public int levelCurrent;
    public bool shouldShowLevelPanel;
    public bool isLevelCompleted;

    private LevelData levelData;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        CheckSaveFile();
        isStart = false;
        shouldShowLevelPanel = false;
        isLevelCompleted = false;
    }

    public void CheckSaveFile()
    {
        if (File.Exists(Application.persistentDataPath + "/Level.json"))
        {
            LoadLevel();
        }
        else
        {
            levelCurrent = 0; // Start with the first level unlocked
            SaveLevel();
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void SaveLevel()
    {
        Debug.Log("Saving level: " + levelCurrent);
        levelData = new LevelData { level = levelCurrent };
        string json = JsonUtility.ToJson(levelData, true);
        File.WriteAllText(Application.persistentDataPath + "/Level.json", json);
    }

    private void LoadLevel()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/Level.json");
        levelData = JsonUtility.FromJson<LevelData>(json);
        levelCurrent = levelData.level;
    }

    public void ChangeLevel(int newLevelUnlocked)
    {
        if (newLevelUnlocked > levelCurrent)
        {
            levelCurrent = newLevelUnlocked;
            SaveLevel();
            Debug.Log("New level unlocked: " + levelCurrent);
        }
    }

    public void ResetLevel()
    {
        levelCurrent = 0;
        SaveLevel();
    }

    public void ReturnToMenu()
    {
        Resume();
        shouldShowLevelPanel = true;
        ChangeScene(0);
    }
}