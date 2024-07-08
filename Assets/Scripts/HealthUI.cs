using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image heartImage;
    [SerializeField] private Sprite heartFull;
    [SerializeField] private Sprite heartThreeQuarters;
    [SerializeField] private Sprite heartHalf;
    [SerializeField] private Sprite heartEmpty;

    void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged.AddListener(UpdateHealthUI);
        }
    }

    public void UpdateHealthUI(float healthPercentage)
    {
        if (heartImage != null)
        {
            if (healthPercentage > 0.75f)
            {
                heartImage.sprite = heartFull;
            }
            else if (healthPercentage > 0.5f)
            {
                heartImage.sprite = heartThreeQuarters;
            }
            else if (healthPercentage > 0.25f)
            {
                heartImage.sprite = heartHalf;
            }
            else
            {
                heartImage.sprite = heartEmpty;
            }
        }
    }
}