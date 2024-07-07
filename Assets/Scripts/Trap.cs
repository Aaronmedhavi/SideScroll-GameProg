using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private float damageAmount = 20f;
    private bool hasBeenTriggered = false;
    private Collider2D trapCollider;

    private void Start()
    {
        trapCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasBeenTriggered) return;

        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
            Debug.Log($"Player hit trap. Damage dealt: {damageAmount}");
            DisableTrap();
        }
    }

    private void DisableTrap()
    {
        hasBeenTriggered = true;
        trapCollider.isTrigger = false;
        Debug.Log("Trap disabled");
    }
}
