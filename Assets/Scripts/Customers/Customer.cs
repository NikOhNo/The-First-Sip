using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;



public class Customer : MonoBehaviour
{
    public class CombinedDrink
    {
        public float Body;
        public float Mind;
        public float Soul;

        public CombinedDrink(Drink d1, Drink d2)
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

    public float difficulty = 1.0f; // 1.0 by default
    public float maxWaitTime; // set upon start()ing
    public float currentWaitTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        maxWaitTime = difficulty * 10.0f;
        // get a random customer data container from Assets/Resources/_CustomerData
        CustomerDataScriptableObject[] customerDatas = Resources.LoadAll<CustomerDataScriptableObject>("_CustomerData");
        customerData = customerDatas[Random.Range(0, customerDatas.Length)];
        Debug.Log($"customer data: {customerData.request}, {customerData.bodyRatio}, {customerData.mindRatio}, {customerData.soulRatio}");
        EnterBar();
    }

    // Update is called once per frame
    void Update()
    {
        currentWaitTime += Time.deltaTime;
        if (currentWaitTime > maxWaitTime)
        {
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
}
