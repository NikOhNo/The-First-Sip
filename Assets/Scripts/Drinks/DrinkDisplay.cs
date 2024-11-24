using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrinkDisplay : DraggableObj, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] DrinkDataSO drinkData;
    [SerializeField] float clickMagnitudeThreshold = 5;
    [SerializeField] float clickTimeThreshold = .2f;

    float clickTimeStart;
    float clickTimeEnd;

    RectTransform rectTransform;
    TMP_Text text;
    SpriteRenderer spriteRenderer;

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.enabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        text.enabled = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        clickTimeStart = Time.time;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        clickTimeEnd = Time.time;

        float clickTime = clickTimeEnd - clickTimeStart;
        if (eventData.delta.magnitude < clickMagnitudeThreshold && clickTime < clickTimeThreshold)
        {
            // TODO: stage the drink
            DrinkManager.Instance.StageDrink(drinkData);
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

        text.enabled = false;
    }


}
