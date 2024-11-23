using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkManager : MonoBehaviour
{
    public static DrinkManager Instance { get; private set; }

    Drink drink1;
    Drink drink2;

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
    public void StageDrink(Drink newDrink)
    {
        drink2 = drink1;
        drink1 = newDrink;
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

        EffectManager.Instance.MakeEffect(drink1, drink2);
    }
}
