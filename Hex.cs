using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color hightLightColor;
    

    private void OnMouseDown()
    {
       spriteRenderer.color = hightLightColor;
    }
}
