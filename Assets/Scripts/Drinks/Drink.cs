using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Drink : MonoBehaviour, IDrink
{
    public DrinkDataSO drinkData;

    public virtual string DrinkName => drinkData.DrinkName;
    public virtual string FlavorText => drinkData.FlavorText;

    public virtual float Mind => drinkData.Mind;
    public virtual float Body => drinkData.Body;
    public virtual float Soul => drinkData.Soul;
    
}
