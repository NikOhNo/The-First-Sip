using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

[CreateAssetMenu(fileName = "newDrinkData", menuName = "New Drink Data")]
public class DrinkDataSO : ScriptableObject
{
    public string DrinkName;
    public string FlavorText;
    public Sprite Sprite;

    public float Mind;
    public float Body;
    public float Soul;
}
