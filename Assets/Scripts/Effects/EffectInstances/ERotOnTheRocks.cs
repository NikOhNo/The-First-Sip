using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERotOnTheRocks : Effect
{

    [SerializeField] private SpriteRenderer blackScreen;
    [SerializeField] private SpriteRenderer fleshBlob;
    void Awake()
    {
        StartCoroutine(ScreenFlash());
        throw new System.NotImplementedException();
    }

    void Update()
    {

        throw new System.NotImplementedException();
    }

    public override void CompleteEffect()
    {
        Destroy(gameObject);
        throw new System.NotImplementedException();
    }

    private IEnumerator ScreenFlash()
    {
        blackScreen.enabled = true;
        fleshBlob.enabled = true;
        yield return new WaitForSeconds(1f);
        blackScreen.enabled = false;
        for (int i = 0; i < 3; i++)
        {
            blackScreen.enabled = true;
            yield return new WaitForSeconds(0.25f);
            blackScreen.enabled = false;
            yield return new WaitForSeconds(0.25f);
        }
        yield return new WaitForSeconds(effectData.Duration);
        blackScreen.enabled = true;
        fleshBlob.enabled = false;
        yield return new WaitForSeconds(1f);
        blackScreen.enabled = false;
        CompleteEffect();
    }

}
