using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour, IEffect
{
    public EffectDataSO effectData;

    public virtual string EffectName => effectData.EffectName;
    public virtual string FlavorText => effectData.FlavorText;
    public virtual float Duration => effectData.Duration;

    public abstract void InitializeEffect();
    public abstract void OnEffect();
    public abstract void CompleteEffect();
}
