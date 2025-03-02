using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetPointer(string _type)
    {
        switch (_type)
        {
            case "open"     :   spriteRenderer.sprite = sprites[0]; break;
            case "passed"   :   spriteRenderer.sprite = sprites[1]; break;
            case "closed"   :   spriteRenderer.sprite = sprites[2]; break;
        }
    }
}
