using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkManager : MonoBehaviour
{
    public static DrinkManager Instance { get; private set; }

    public DrinkDataSO drink1;
    public DrinkDataSO drink2;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    /// <summary>
    /// stages a new drink to possibly be combined,
    /// discards the older drink thats been staged longer 
    /// (ie: stage red, stage blue, stage green - red discarded)
    /// </summary>
    /// <param name="newDrink"></param>
    public void StageDrink(DrinkDataSO newDrink)
    {
        Debug.Log("Staging: " + newDrink.DrinkName);

        drink2 = drink1;
        drink1 = newDrink;
        CombineDrinks();
    }

    /// <summary>
    /// Combines 2 drinks to gain an effect and stats to satisfy customer
    /// </summary>
    public void CombineDrinks()
    {
        if (drink1 == null || drink2 == null)
        {
            return;
        }

        Customer currentCustomer = CustomerManager.Instance.CurrentCustomer();
        if (currentCustomer != null)
            currentCustomer.GetComponent<Customer>().GiveDrink();

        var newEffect = EffectManager.Instance.MakeEffect(drink1, drink2);
        if (newEffect)
        {
            Debug.Log("Made Effect: " + newEffect.EffectName);  
        }
        drink1 = null;
        drink2 = null;
    }
}
