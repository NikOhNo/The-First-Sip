using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DrinkDisplay : MonoBehaviour
{
    [SerializeField] DrinkDataSO drinkData;

    RectTransform rectTransform;
    TMP_Text text;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        text = GetComponentInChildren<TMP_Text>();     
        spriteRenderer = GetComponent<SpriteRenderer>();

        text.text = drinkData.DrinkName;
        spriteRenderer.sprite = drinkData.Sprite;
    }


}
