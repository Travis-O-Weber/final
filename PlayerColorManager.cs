using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColorManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float grayScale = 1.0f; // Start at white

void Awake() {
    spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    if (spriteRenderer == null) {
        Debug.LogError("SpriteRenderer not found in any children of the GameObject.");
    }
}

    public void DarkenColor()
    {
        Debug.Log("DarkenColor called. Current grayscale: " + grayScale);
        grayScale -= 0.2f; // Adjust this value to control how quickly the color changes
        grayScale = Mathf.Max(grayScale, 0); // Clamp to minimum 0 to avoid going negative
        spriteRenderer.color = new Color(grayScale, grayScale, grayScale, 1);
    }
}