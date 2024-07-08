using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonEnemy : MonoBehaviour
{
    [Header("Cannon")]
    public float health = 100f;
    public float fireRate = 2f;
    public float detectionRange = 10f;

    [Header("Fireball")]
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float fireballSpeed = 10f;

    private float nextFireTime;
    private Transform player;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange && Time.time >= nextFireTime)
        {
            FireAtPlayer();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void FireAtPlayer()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        Vector2 direction = (player.position - firePoint.position).normalized;
        rb.velocity = direction * fireballSpeed;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        StartCoroutine(FlashRed());
        if (health <= 0)
        {
            Die();
        }
    }

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = originalColor;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
