using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    string EffectName { get; }
    string FlavorText { get; }
    float Duration { get; }
    

    void InitializeEffect();
    void OnEffect();
    void CompleteEffect();
}
