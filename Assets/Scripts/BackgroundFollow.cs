using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Camera mainCamera;
    public float parallaxEffect = 0.3f;

    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;

    void Start()
    {
        lastCameraPosition = mainCamera.transform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = mainCamera.transform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffect, deltaMovement.y * parallaxEffect, 0);
        lastCameraPosition = mainCamera.transform.position;

        if (Mathf.Abs(mainCamera.transform.position.x - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = (mainCamera.transform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(mainCamera.transform.position.x + offsetPositionX, transform.position.y);
        }
    }
}
