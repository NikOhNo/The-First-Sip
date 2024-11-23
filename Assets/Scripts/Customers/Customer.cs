using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public CustomerDataScriptableObject customerData;

    // Start is called before the first frame update
    void Start()
    {
        // get a random customer data container from Assets/Resources/_CustomerData
        CustomerDataScriptableObject[] customerDatas = Resources.LoadAll<CustomerDataScriptableObject>("_CustomerData");
        customerData = customerDatas[Random.Range(0, customerDatas.Length)];
        Debug.Log($"customer data: {customerData.request}, {customerData.bodyRatio}, {customerData.mindRatio}, {customerData.soulRatio}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
