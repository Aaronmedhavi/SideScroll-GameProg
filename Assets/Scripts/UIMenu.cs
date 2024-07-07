using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject startPanel;
    public GameObject levelPanel;

    [Header("Buttons")]
    public Button startButton;

    [Header("Level Selection Buttons")]
    public int levelCurrent;
    public Button[] levelButtons;

    void Start()
    {
        GameManager.Instance.CheckSaveFile();
        levelCurrent = GameManager.Instance.levelCurrent;

        InitializeStartButton();
        AddChangeSceneListeners();
        RefreshLevelButtons();
        CheckPanelToShow();
    }

    private void InitializeStartButton()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(OnStartButtonClick);
        }
        else
        {
            Debug.LogError("Start button is not assigned in the inspector!");
        }
    }

    public void OnStartButtonClick()
    {
        ShowLevelPanel();
        GameManager.Instance.isStart = true;
        GameManager.Instance.SaveLevel();
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
            levelButtons[i].interactable = (i <= levelCurrent);
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
            Debug.LogError("Start Panel or Level Panel is not assigned in the inspector!");
        }
    }
}