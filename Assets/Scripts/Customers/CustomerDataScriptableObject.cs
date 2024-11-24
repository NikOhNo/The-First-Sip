using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CustomerDataScriptableObject", order = 1)]
public class CustomerDataScriptableObject : ScriptableObject
{
    public string request = "if you're seeing this, something went wrong (unset request)";

    public float bodyRatio;
    public float mindRatio;
    public float soulRatio;
}