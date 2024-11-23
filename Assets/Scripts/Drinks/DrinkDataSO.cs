using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDrinkData", menuName = "New Drink Data")]
public class DrinkDataSO : ScriptableObject
{
    public string DrinkName;
    public string FlavorText;

    public float Mind;
    public float Body;
    public float Soul;
}
