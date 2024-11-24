using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSlotManager : MonoBehaviour
{
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
