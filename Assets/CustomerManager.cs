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
        return customerQueue.Peek().GetComponent<Customer>();
    }
}
