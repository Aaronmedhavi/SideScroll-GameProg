using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private float respawnDelay = 0.5f;
    [SerializeField] private float testDamageAmount = 10f;

    public UnityEvent<float> OnHealthChanged;
    public UnityEvent OnPlayerDeath;
    public UnityEvent OnPlayerRespawn;

    private Animator animator;
    private PlayerMovement playerMovement;
    private PlayerPositionHandler positionHandler;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged.Invoke(currentHealth / maxHealth);
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        positionHandler = GetComponent<PlayerPositionHandler>();
    }

    void Update()
    {
        // Test key to reduce health
        if (Input.GetKeyDown(KeyCode.T) && !isDead)
        {
            TakeDamage(testDamageAmount);
        }
    }

    public void TakeDamage(float damage)
    {
        if (isDead) return;
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        OnHealthChanged.Invoke(currentHealth / maxHealth);
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        if (isDead) return;
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        OnHealthChanged.Invoke(currentHealth / maxHealth);
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        OnPlayerDeath.Invoke();
        playerMovement.enabled = false;
        animator.SetTrigger("goDeath");
        AudioManager.Instance.PlayDeathSound();
        StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        Respawn();
    }

    private void Respawn()
    {
        isDead = false;
        currentHealth = maxHealth;
        OnHealthChanged.Invoke(currentHealth / maxHealth);
        playerMovement.enabled = true;
        animator.SetTrigger("goRespawn");
        positionHandler.ChangePlayerPosition(positionHandler.GetRespawnPosition());
        OnPlayerRespawn.Invoke();
    }

    public void RespawnAtLastCheckpoint()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        playerMovement.enabled = false;
        animator.SetTrigger("goDeath");
        AudioManager.Instance.PlayDeathSound();
        yield return new WaitForSeconds(respawnDelay);
        currentHealth = maxHealth;
        OnHealthChanged.Invoke(currentHealth / maxHealth);
        Vector2 respawnPosition = positionHandler.GetRespawnPosition();
        transform.position = respawnPosition;
        playerMovement.enabled = true;
        animator.SetTrigger("goRespawn");
        OnPlayerRespawn.Invoke();
    }
}