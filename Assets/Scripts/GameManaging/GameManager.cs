using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //
    public float difficulty = 1.0f;
    public float baseCustomerInterval = 5.0f; // seconds
    private float currentCustomerInterval = 0.0f;

    // customers
    public List<string> taglines;
    public GameObject customerPrefab;

    // lose game stuff
    public GameObject gameOverCanvas;
    public bool gameIsLost = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check for sending customer
        currentCustomerInterval += Time.deltaTime;
        if (currentCustomerInterval >= baseCustomerInterval / difficulty)
        {
            currentCustomerInterval = 0.0f;
            SendCustomer();
        }
    }

    void SendCustomer()
    {
        Instantiate(customerPrefab);
        Debug.Log("trying to send a customer");
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
