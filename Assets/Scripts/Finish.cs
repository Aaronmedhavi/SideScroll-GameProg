using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private int nextLevelToUnlock;
    [SerializeField] private int levelSelectionSceneIndex = 0; // Assuming level selection is scene 0

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        // Unlock the next level
        GameManager.Instance.ChangeLevel(nextLevelToUnlock);
        GameManager.Instance.isLevelCompleted = true;

        // Load the level selection scene
        SceneManager.LoadScene(levelSelectionSceneIndex);
    }
}