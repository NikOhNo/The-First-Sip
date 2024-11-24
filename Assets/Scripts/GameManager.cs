using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Runtime Vars
    private int difficulty;
    private float timer;
    private float maxTimer = 10;
    public GameObject customer;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one GameManager in SCene!");
        }
        Instance = this;
    }

    private void Start()
    {
        if (timer <= 0)
        {
            Instantiate(customer);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    //Recieve global customer served event

}
