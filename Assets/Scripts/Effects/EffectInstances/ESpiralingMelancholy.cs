using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpiralingMelancholy : Effect
{
    private GameObject mainCamera;
    private float rotationSpeed;
    private float timer;
    void Awake()
    {
        timer = effectData.Duration;
        mainCamera = GameObject.Find("Main Camera");
        rotationSpeed = Random.Range(-10, 10);
    }

    void Update()
    {
        Debug.Log("yayyay");    
        
        if (timer <= 0)
        {
            float zRotation = mainCamera.transform.eulerAngles.z;
            zRotation = Mathf.Round(zRotation / 360f) * 360f;
            mainCamera.transform.rotation = Quaternion.Euler(0, 0, zRotation);
            CompleteEffect();
        }
        else
        {
            timer -= Time.deltaTime;
            rotationSpeed += 0.5f * rotationSpeed / rotationSpeed;
            float stepRotation = rotationSpeed * Time.deltaTime;
            mainCamera.transform.Rotate(Vector3.forward, stepRotation);
        }
    }

    public override void CompleteEffect()
    {
        Destroy(gameObject);
    }
}
