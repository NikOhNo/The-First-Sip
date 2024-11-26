using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static CustomerManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Queue<GameObject> customerQueue = new();

    public Customer CurrentCustomer()
    {
        if (customerQueue.Count > 0)
            return customerQueue.Peek().GetComponent<Customer>();
        else
        {
            Debug.LogWarning("No customers in queue");
            return null;
        } 
    }
}
