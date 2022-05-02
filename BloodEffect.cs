using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{


    public enum SplatLocation 
    {
        Ground,
        BehindPlayer,
        
    }

    public Color backgroundTint;
    public float minSizeMod = 0.8f;
    public float maxSizeMod = 1.5f;

    public Sprite[] sprites;

    private SplatLocation splatLocation;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
 
    public void Initialize(SplatLocation splatLocation)
    {
        this.splatLocation = splatLocation;
        SetSprite();
        SetSize();
        SetLocationProperties();
    }

    private void SetSprite()
    {
        int randomIndex = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[randomIndex];
    }

    private void SetSize()
    {
        float sizeMod = Random.Range(minSizeMod, maxSizeMod);
        transform.localScale *= sizeMod; 
    }

    private void SetLocationProperties()
    {
        switch(splatLocation)
        {
            case SplatLocation.BehindPlayer:
                spriteRenderer.color = backgroundTint;
                spriteRenderer.sortingOrder = 0;
                break;
            
            case SplatLocation.Ground:
                spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                spriteRenderer.sortingOrder = 7;
                break;
        }
    }
}
