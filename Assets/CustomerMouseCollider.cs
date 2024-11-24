using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomerMouseCollider : MonoBehaviour

{
    public GameObject customer;
    public void OnMouseDown()
    {
        Debug.Log("meoow");
        customer.GetComponent<Customer>().GiveDrink();
    }
}
