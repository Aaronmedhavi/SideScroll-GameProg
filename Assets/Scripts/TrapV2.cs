using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapV2 : MonoBehaviour
{
    [SerializeField] private float damageAmount = 20f;
    [SerializeField] private float damageInterval = 1f;
    private float lastDamageTime;
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            if (Time.time >= lastDamageTime + damageInterval)
            {
                DealDamage(playerHealth);
            }
        }
    }
    private void DealDamage(PlayerHealth playerHealth)
    {
        playerHealth.TakeDamage(damageAmount);
        lastDamageTime = Time.time;
    }
}