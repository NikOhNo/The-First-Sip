using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour, IEffect
{
    public abstract float Duration { get; }

    public abstract void OnEffect();
}
