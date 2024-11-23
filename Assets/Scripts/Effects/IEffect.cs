using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    string EffectName { get; }
    string FlavorText { get; }
    float Duration { get; }
    

    bool ValidRecipe(Drink drink1, Drink drink2);
    void InitializeEffect();
    void OnEffect();
    void CompleteEffect();
}
