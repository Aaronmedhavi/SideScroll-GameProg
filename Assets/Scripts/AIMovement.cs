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
        lastPosition = transform.position.x;
    }

    void Update()
    {
        float newX = originalPos + Mathf.Sin(t) * distance;
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        t += speed * Time.deltaTime;
        if (spriteRenderer != null)
        {
            if (transform.position.x > lastPosition)
            {
                spriteRenderer.flipX = false;
            }
            else if (transform.position.x < lastPosition)
            {
                spriteRenderer.flipX = true;
            }
        }
        lastPosition = transform.position.x;
    }
}
