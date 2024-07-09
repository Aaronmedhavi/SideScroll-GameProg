using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private int nextLevelToUnlock;
    [SerializeField] private UIGameplay uiGameplay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        int currentLevel = GameManager.Instance.levelCurrent;
        if (nextLevelToUnlock > currentLevel)
        {
            GameManager.Instance.ChangeLevel(nextLevelToUnlock);
        }
        GameManager.Instance.isLevelCompleted = true;
        uiGameplay.ShowWinUI(nextLevelToUnlock);
    }
}