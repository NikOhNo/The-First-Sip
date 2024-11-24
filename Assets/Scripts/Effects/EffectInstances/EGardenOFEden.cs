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
        throw new System.NotImplementedException();
    }

    void Update()
    {
        if (timer <= 0)
        {
            CompleteEffect();
        }
        throw new System.NotImplementedException();
    }

    public override void CompleteEffect()
    {
        Destroy(gameObject);
    }

}
