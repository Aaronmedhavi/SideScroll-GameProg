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

    private void Start()
    {
        InitializeButtons();
        HidePauseUI();
    }

    private void InitializeButtons()
    {
        if (buttonMenu != null)
            buttonMenu.onClick.AddListener(ReturnToLevelSelection);
        else
            Debug.LogError("Menu button is not assigned!");
        if (buttonPause != null)
            buttonPause.onClick.AddListener(PauseGame);
        else
            Debug.LogError("Pause button is not assigned!");
        if (buttonResume != null)
            buttonResume.onClick.AddListener(ResumeGame);
        else
            Debug.LogError("Resume button is not assigned!");
    }

    private void PauseGame()
    {
        GameManager.Instance.Pause();
        AudioManager.Instance.PauseBackgroundMusic();
        ShowPauseUI();
    }

    private void ResumeGame()
    {
        GameManager.Instance.Resume();
        AudioManager.Instance.ResumeBackgroundMusic();
        HidePauseUI();
    }

    private void ReturnToLevelSelection()
    {
        AudioManager.Instance.ResumeBackgroundMusic();
        GameManager.Instance.ReturnToMenu();
    }

    private void ShowPauseUI()
    {
        if (pausePanel != null)
            pausePanel.SetActive(true);
        if (buttonPause != null)
            buttonPause.gameObject.SetActive(false);
        if (buttonResume != null)
            buttonResume.gameObject.SetActive(true);
    }

    private void HidePauseUI()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);
        if (buttonPause != null)
            buttonPause.gameObject.SetActive(true);
        if (buttonResume != null)
            buttonResume.gameObject.SetActive(false);
    }
}