using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECosmicJourneysEnd : Effect
{
    private float timer;

    void Awake()
    {
        Time.timeScale = 1.5f;
        timer = effectData.Duration;
        throw new System.NotImplementedException();
    }

    void Update()
    {
        if (timer <= 0)
        {
            Time.timeScale = 1.0f;
            CompleteEffect();
        }
        else
            timer -= Time.unscaledDeltaTime;
        throw new System.NotImplementedException();
    }

    public override void CompleteEffect()
    {
        Destroy(gameObject);
    }
}


