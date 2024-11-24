using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrinkDisplay : DraggableObj, IPointerClickHandler
{
    [SerializeField] DrinkDataSO drinkData;
    [SerializeField] float clickMagnitudeThreshold = 5;

    RectTransform rectTransform;
    TMP_Text text;
    SpriteRenderer spriteRenderer;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.delta.magnitude < clickMagnitudeThreshold)
        {
            // TODO: stage the drink
            Debug.Log("click!");
        }
    }

    protected override void Awake()
    {
        base.Awake();

        rectTransform = GetComponent<RectTransform>();
        text = GetComponentInChildren<TMP_Text>();     
        spriteRenderer = GetComponent<SpriteRenderer>();

        text.text = drinkData.DrinkName;
        spriteRenderer.sprite = drinkData.Sprite;
    }


}
