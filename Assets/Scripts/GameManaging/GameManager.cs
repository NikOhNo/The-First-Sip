using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    //
    public float difficulty = 1.0f;
    public float baseCustomerInterval = 1.0f; // seconds
    private float currentCustomerInterval = 0.0f;

    // customers
    public List<string> taglines;
    public GameObject customerPrefab;
    public Dictionary<int, GameObject> customerDict = new();
    public GameObject customerSlots;

    // lose game stuff
    public GameObject gameOverCanvas;
    public bool gameIsLost = false;

   

    // Update is called once per frame
    void Update()
    {
        // check for sending customer
        currentCustomerInterval += Time.deltaTime;
        if (currentCustomerInterval >= (baseCustomerInterval / difficulty))
        {
            currentCustomerInterval = 0.0f;
            SendCustomer();
        }
    }

    void SendCustomer()
    {

        // just create a customer
        GameObject customer = Instantiate(customerPrefab);
        Debug.Log($"sending customer {customer}");
        var component = customerSlots.GetComponent<CustomerSlotManager>();

        var slot = component.FindOpenSlot();
        slot.GetComponent<CustomerSlot>().customer = customer;
        //customer.transform.parent = slot.transform;
        customer.transform.position = slot.transform.position;
        customer.transform.position = new Vector3(customer.transform.position.x, customer.transform.position.y, 0.0f);
        //customer.transform.position = new Vector2(0.0f, 0.0f);
 
        customerDict.Add(customer.GetInstanceID(), customer); // maybe don't use instance id to index into the dict
    }
        //customer.transform.parent = slot.transform;

    /// <summary>
    /// give drink to the given customer
    /// </summary>
    /// <param name="customerId">instance id of the customer object</param>
    /// <param name="drink"></param>
    public void GiveDrinkToCustomer(int customerId, Drink drink)
    {
        // FIXME convert drink parameter to a "combo" or something of the like
        customerDict.TryGetValue(customerId, out GameObject obj);
        if (obj != null)
        {
            obj.GetComponent<Customer>().GiveDrink();
        }
        else
        {
            Debug.LogError($"attempted to give drink to nonexistent customer with id {customerId}");
        }
    }

    public void OnLoseGame()
    {
        if (!gameIsLost)
        {
            gameIsLost = true;
            Instantiate(gameOverCanvas);
        }
    }
}
