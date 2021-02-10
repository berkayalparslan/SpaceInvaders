using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceInitializer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
}
