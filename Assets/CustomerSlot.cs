using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerSlot : MonoBehaviour
{
    public GameObject customer;

    private void Start()
    {
        customer = null;
    }

    public bool IsOpen()
    {
        Debug.Log("is open");
        return (customer == null);
    }

    public GameObject EvictSlot()
    {
        var temp = customer;
        customer = null;
        return temp;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
