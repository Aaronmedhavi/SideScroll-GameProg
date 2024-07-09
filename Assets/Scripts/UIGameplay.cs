using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour
{
    [Header("Scene Index")]
    [SerializeField] private int menuSceneIndex = 0;
    [Header("Gameplay UI Elements")]
    public Button buttonResume;
    public Button buttonPause;
    public Button buttonMenu;
    public GameObject pausePanel;
    private bool isPaused = false;
    [Header("Win Panel")]
    public GameObject winPanel;
    public TextMeshProUGUI winTimerText;
    public Button winContinueButton;

    private float levelStartTime;

    void Start()
    {
        InitializeButtons();
        HidePauseUI();
        HideWinUI();
        levelStartTime = Time.time;
    }

    private void InitializeButtons()
    {
        buttonMenu.onClick.AddListener(ReturnToLevelSelection);
        buttonPause.onClick.AddListener(PauseGame);
        buttonResume.onClick.AddListener(ResumeGame);
        winContinueButton.onClick.AddListener(ReturnToLevelSelection);

    }

    private void PauseGame()
    {
        GameManager.Instance.Pause();
        AudioManager.Instance.PauseBackgroundMusic();
        ShowPauseUI();
        isPaused = true;

    }

    private void ResumeGame()
    {
        GameManager.Instance.Resume();
        AudioManager.Instance.ResumeBackgroundMusic();
        HidePauseUI();
        isPaused = false;

    }

    private void ReturnToLevelSelection()
    {
        GameManager.Instance.Resume();
        AudioManager.Instance.ResumeBackgroundMusic();
        GameManager.Instance.ReturnToMenu();
    }

    private void ShowPauseUI()
    {
        pausePanel.SetActive(true);
        buttonPause.gameObject.SetActive(false);
        buttonResume.gameObject.SetActive(true);
    }

    private void HidePauseUI()
    {
        pausePanel.SetActive(false);
        buttonPause.gameObject.SetActive(true);
        buttonResume.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    public void ShowWinUI(int nextLevelToUnlock)
    {
        float levelTime = Time.time - levelStartTime;
        winTimerText.text = $"Time: {levelTime:F2} seconds";
        winPanel.SetActive(true);
        GameManager.Instance.Pause();
    }
    private void HideWinUI()
    {
        winPanel.SetActive(false);
    }
}