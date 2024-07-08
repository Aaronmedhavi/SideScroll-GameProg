using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{
    [SerializeField] private Vector2 playerCurrentPosition;
    [SerializeField] private Vector2 currentCheckpointPosition;
    [SerializeField] private Vector2 startingPosition;
    public TransformData playerPositionData;
    private TriggerEvent playerTriggerEvent;
    private bool hasReachedCheckpoint = false;

    void Start()
    {
        playerTriggerEvent = GetComponent<TriggerEvent>();
        startingPosition = transform.position;
        currentCheckpointPosition = startingPosition;
    }

    public void OnCheckpoint(GameObject col)
    {
        Vector2 newCheckpointPosition = col.transform.position;
        currentCheckpointPosition = newCheckpointPosition;
        SavePosition(currentCheckpointPosition);
        CheckpointWallActive(col);
        hasReachedCheckpoint = true;
    }

    public void CheckpointWallActive(GameObject wall)
    {
        wall.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OnFinish()
    {
        playerPositionData.ResetData();
    }

    public void ChangePlayerPosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    private void LoadPosition()
    {
        playerCurrentPosition = playerPositionData.position;
    }

    private void SavePosition(Vector2 newPosition)
    {
        playerPositionData.position = newPosition;
    }

    public Vector2 GetRespawnPosition()
    {
        return hasReachedCheckpoint ? currentCheckpointPosition : startingPosition;
    }

    public void ResetCheckpoint()
    {
        hasReachedCheckpoint = false;
        currentCheckpointPosition = startingPosition;
    }
}