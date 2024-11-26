using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGardenOFEden : Effect
{
    
    [SerializeField] private Vector2 fruitSpawnLocation;
    private float timer;
    void Awake()
    {
        transform.position = fruitSpawnLocation;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        timer = effectData.Duration;
    }

    void Update()
    {
        if (timer <= 0)
        {
            CompleteEffect();
        }
    }

    public override void CompleteEffect()
    {
        Destroy(gameObject);
    }

}
