using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour, IEffect
{
    public EffectDataSO effectData;
    //public bool effectEnded;

    public virtual string EffectName => effectData.EffectName;
    public virtual string FlavorText => effectData.FlavorText;
    public virtual float Duration => effectData.Duration;
    public abstract void CompleteEffect();

}
