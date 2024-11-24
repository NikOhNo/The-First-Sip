using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEffectData", menuName = "New Effect Data")]
public class EffectDataSO : ScriptableObject
{
    public string EffectName;
    public float Duration;
    public string FlavorText;

    public List<Recipe> Recipes = new();
}

[System.Serializable]
public class Recipe
{
    public DrinkDataSO drink1;
    public DrinkDataSO drink2;

    public bool CanMakeWith(DrinkDataSO drink1, DrinkDataSO drink2)
    {
        if (drink1 == this.drink1 && drink2 == this.drink2)
        {
            return true;
        }
        else if (drink2 == this.drink1 && drink1 == this.drink2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}