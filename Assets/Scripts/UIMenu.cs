using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject startPanel;
    public GameObject levelPanel;
    [Header("Button")]
    public Button startButton;
    public Button quitButton;
    public Button backButton;
    [Header("Level Selection Button")]
    public int levelCurrent;
    public Button[] levelButtons;
    [Header("Reset Button")]
    public Button resetButton;

    void Start()
    {
        GameManager.Instance.CheckSaveFile();
        levelCurrent = GameManager.Instance.levelCurrent;
        InitializeButtons();
        AddChangeSceneListeners();
        RefreshLevelButtons();
        CheckPanelToShow();
        InitializeResetButton();
    }

    private void InitializeButtons()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(OnStartButtonClick);
        }
        else
        {
            Debug.LogError("Start button is not assigned in the inspector!");
        }

        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame);
        }
        else
        {
            Debug.LogError("Quit button is not assigned in the inspector!");
        }
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClick);
        }
        else
        {
            Debug.LogError("Back button is not assigned in the inspector!");
        }
    }

    public void OnStartButtonClick()
    {
        ShowLevelPanel();
        GameManager.Instance.isStart = true;
        GameManager.Instance.SaveLevel();
    }
    public void OnBackButtonClick()
    {
        ShowStartPanel();
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowLevelPanel()
    {
        if (startPanel != null && levelPanel != null)
        {
            startPanel.SetActive(false);
            levelPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Start Panel or Level Panel is not assigned in the inspector!");
        }
    }

    private void AddChangeSceneListeners()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int sceneIndex = i + 1;
            levelButtons[i].onClick.AddListener(() => GameManager.Instance.ChangeScene(sceneIndex));
        }
    }

    private void RefreshLevelButtons()
    {
        levelCurrent = GameManager.Instance.levelCurrent;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i == 0 || i <= levelCurrent)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    private void CheckPanelToShow()
    {
        if (GameManager.Instance.shouldShowLevelPanel || GameManager.Instance.isLevelCompleted)
        {
            ShowLevelPanel();
            GameManager.Instance.shouldShowLevelPanel = false;
            GameManager.Instance.isLevelCompleted = false;
            RefreshLevelButtons();
        }
        else if (GameManager.Instance.isStart)
        {
            ShowLevelPanel();
        }
        else
        {
            ShowStartPanel();
        }
    }

    public void ShowStartPanel()
    {
        if (startPanel != null && levelPanel != null)
        {
            startPanel.SetActive(true);
            levelPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Start Panel/Level Panel not assigned");
        }
    }
    private void InitializeResetButton()
    {
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetGameProgress);
        }
        else
        {
            Debug.LogError("Reset button is not assigned in the inspector!");
        }
    }
    public void ResetGameProgress()
    {
        GameManager.Instance.ResetLevel();
        RefreshLevelButtons();
    }
}