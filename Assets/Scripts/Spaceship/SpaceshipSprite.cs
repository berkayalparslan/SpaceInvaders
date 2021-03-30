using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipSprite : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
}
