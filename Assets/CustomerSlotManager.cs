using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSlotManager : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;

    public GameObject GetNextOpenSlot()
    {
        // should go in order i think
         foreach (var c in GetComponentsInChildren<CustomerSlot>())
        {
            if (c.IsOpen())
            {
                return c.gameObject;
            }
        }
        return null;
    }

    public void RemoveFrontCustomer()
    {
        //slot1.GetComponent<Customer>().LeaveBar();

        slot1.GetComponent<CustomerSlot>().customer = slot2.GetComponent<CustomerSlot>().customer;
        if (slot1.GetComponent<CustomerSlot>().customer != null)
        {
            slot1.GetComponent<CustomerSlot>().customer.transform.position = slot1.transform.position;
            slot1.GetComponent<CustomerSlot>().customer.transform.position = new Vector3(slot1.GetComponent<CustomerSlot>().customer.transform.position.x, slot1.GetComponent<CustomerSlot>().customer.transform.position.y, 0.0f);
        }
        slot2.GetComponent<CustomerSlot>().customer = slot3.GetComponent<CustomerSlot>().customer;
        if (slot2.GetComponent<CustomerSlot>().customer != null)
        {
            slot2.GetComponent<CustomerSlot>().customer.transform.position = slot2.transform.position;
            slot2.GetComponent<CustomerSlot>().customer.transform.position = new Vector3(slot2.GetComponent<CustomerSlot>().customer.transform.position.x, slot2.GetComponent<CustomerSlot>().customer.transform.position.y, 0.0f);
        }
        slot3.GetComponent<CustomerSlot>().customer = slot4.GetComponent<CustomerSlot>().customer;
        if (slot3.GetComponent<CustomerSlot>().customer != null)
        {
            slot3.GetComponent<CustomerSlot>().customer.transform.position = slot3.transform.position;
            slot3.GetComponent<CustomerSlot>().customer.transform.position = new Vector3(slot3.GetComponent<CustomerSlot>().customer.transform.position.x, slot3.GetComponent<CustomerSlot>().customer.transform.position.y, 0.0f);
        }
        slot4.GetComponent<CustomerSlot>().customer = null;
    }

    public GameObject AddCustomer(GameObject customer)
    {
        foreach (var c in GetComponentsInChildren<CustomerSlot>())
        {
            if (c.IsOpen())
            {
                Debug.Log(c);
                c.customer = customer;
                return c.gameObject;
            }
        }

        return null;
    }

    public GameObject FindOpenSlot()
    {
        foreach (var c in GetComponentsInChildren<CustomerSlot>())
        {
            if (c.IsOpen())
            {
                return c.gameObject;
            }
        }

        float minTimeLeft = 100.0f;
        GameObject slotToEvict = transform.GetChild(0).gameObject; // fuck you firstborn
        // none open, kick out customer with least patience
        Debug.Log("evicting");
        foreach (var c in GetComponentsInChildren<CustomerSlot>())
        {
            if (c.customer != null)
            {
                var customerComponent = c.customer.GetComponent<Customer>();
                if (customerComponent.currentWaitTime < minTimeLeft)
                {
                    minTimeLeft = customerComponent.currentWaitTime;
                    slotToEvict = c.gameObject;
                }
            }

        }
        slotToEvict.GetComponent<CustomerSlot>().customer.GetComponent<Customer>().LeaveBar(true); // force them to leave
        slotToEvict.GetComponent<CustomerSlot>().customer = null;

        return slotToEvict;
    }
}
