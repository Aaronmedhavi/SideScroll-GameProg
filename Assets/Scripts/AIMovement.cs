using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float distance = 5f;
    public float speed = 1f;

    private float originalPos;
    private float t = 0.0f;
    private SpriteRenderer spriteRenderer;
    private float lastPosition;

    void Start()
    {
        originalPos = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on this GameObject!");
        }
        lastPosition = transform.position.x;
    }

    void Update()
    {
        // Calculate new position
        float newX = originalPos + Mathf.Sin(t) * distance;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);

        // Update time
        t += speed * Time.deltaTime;

        // Determine direction and flip sprite if necessary
        if (spriteRenderer != null)
        {
            if (transform.position.x > lastPosition)
            {
                spriteRenderer.flipX = false; // Moving right, no flip
            }
            else if (transform.position.x < lastPosition)
            {
                spriteRenderer.flipX = true; // Moving left, flip
            }
        }

        // Update last position for next frame
        lastPosition = transform.position.x;
    }
}
