using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }

    [SerializeField] List<EffectDataSO> effects = new();
    [SerializeField] List<GameObject> effectPrefabs = new();

    readonly List<Effect> activeEffects = new();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        foreach (Effect effect in activeEffects)
        {
            effect.OnEffect();
        }
    }

    /// <summary>
    /// iterates through all effects and makes the one with a matching recipe
    /// </summary>
    public Effect MakeEffect(Drink drink1, Drink drink2)
    {
        foreach (EffectDataSO effect in effects)
        {
            foreach (Recipe recipe in effect.Recipes)
            {
                if (recipe.CanMakeWith(drink1, drink2))
                {
                    return MakeEffect(effect);
                }    
            }
        }

        Debug.LogError($"Could not find effect with recipe: \"{drink1.DrinkName}\" and \"{drink2.DrinkName}\"");
        return null;
    }

    /// <summary>
    /// Makes an effect from data & initializes it
    /// </summary>
    /// <returns></returns>
    public Effect MakeEffect(EffectDataSO data)
    {
        foreach (var effectPrefab in effectPrefabs)
        {
            Effect effect = effectPrefab.GetComponent<Effect>();
            if (effect.effectData == data)
            {
                Effect newEffect = Instantiate(effectPrefab, transform).GetComponent<Effect>();
                newEffect.InitializeEffect();
                return newEffect;
            }
        }

        Debug.LogError($"Could not find effect prefab with data: \"{data.name}\"");
        return null;
    }
}
