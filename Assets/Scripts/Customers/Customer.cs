using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;



public class Customer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public class CombinedDrink
    {
        public float Body;
        public float Mind;
        public float Soul;

        public CombinedDrink(DrinkDataSO d1, DrinkDataSO d2)
        {
            // i think this is how you combine ratios.
            Body = (d1.Body + d2.Body) / 2;
            Mind = (d1.Mind + d2.Mind) / 2;
            Soul = (d1.Soul + d2.Soul) / 2;
        }
    }

    public CustomerDataScriptableObject customerData;
    public SpriteRenderer spriteRenderer;
    public TextMeshPro speechText;

    public GameObject speechContainer;

    public BoxCollider2D boxCollider;

    public float difficulty = 1.0f; // 1.0 by default
    public float maxWaitTime = 10.0f; // also set upon start()ing
    public float currentWaitTime = 0.0f;

    // Start is called before the first frame update
    private void Awake()
    {
        maxWaitTime = difficulty * 10.0f;
    }
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //boxCollider.size = spriteRenderer.sprite.textureRect.size;
        
        Debug.Log(maxWaitTime);
        // get a random customer data container from Assets/Resources/_CustomerData
        CustomerDataScriptableObject[] customerDatas = Resources.LoadAll<CustomerDataScriptableObject>("_CustomerData");
        customerData = customerDatas[Random.Range(0, customerDatas.Length)];
        Debug.Log($"customer data: {customerData.request}, {customerData.bodyRatio}, {customerData.mindRatio}, {customerData.soulRatio}");

        // get a random sprite from Assets/Resources/CustomerSprites
        Sprite[] customerSprites = Resources.LoadAll<Sprite>("CustomerSprites");
        spriteRenderer.sprite = customerSprites[Random.Range(0, customerSprites.Length)];
        
        
        EnterBar();
    }

    // Update is called once per frame
    void Update()
    {
        currentWaitTime += Time.deltaTime;
        //Debug.Log(currentWaitTime);
        
        if (currentWaitTime > maxWaitTime)
        {
            currentWaitTime = 0.0f;
            LeaveBar(true);
        }
    }

    public void GiveDrink()
    {
        CombinedDrink combinedDrink;
        if (DrinkManager.Instance.drink1 != null && DrinkManager.Instance.drink2 != null)
        {
            combinedDrink = new CombinedDrink(DrinkManager.Instance.drink1, DrinkManager.Instance.drink2);
        }
        else
        {
            Debug.LogError("none or just one drink staged!");
            return;
        }

        float bodyDiff = combinedDrink.Body - customerData.bodyRatio;
        float mindDiff = combinedDrink.Mind - customerData.mindRatio;
        float soulDiff = combinedDrink.Soul - customerData.soulRatio;

        // get total difference, normalize it
        float totalDiff = bodyDiff + mindDiff + soulDiff;
        CompleteOrder(totalDiff);
    }

    public void EnterBar()
    {
        // slide over from left side of the screen or something very silly-ly
        //transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        speechText.text = customerData.request;

    }


    public void CompleteOrder(float totalDiff)
    {
        // emit order complete with grade or something
        Debug.Log($"completed order with total diff as: {totalDiff}");
        LeaveBar();
    }

    public void LeaveBar(bool timedOut = false)
    {
        Destroy(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //speechContainer.SetActive(true);
        speechText.enabled = true;
        Debug.Log("BEANS");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //speechContainer.SetActive(false);
        speechText.enabled = false;
    }
}
