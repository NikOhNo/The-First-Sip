using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ESeraphimsGaze : Effect
{
    [SerializeField] private GameObject screenBrighten;
    private string annoyingAssTextScroll = "DO YOU THINK YOUR MERE MORTAL EYES ARE PRITHY TO GAZE UPON OUR FATHER ALL MIGHTY AND HIS FORM? THE SHAPE OF GOD IS INCOMPREHENSIBLE AND THE DESIRE WHICH YOU ATTEMPT TO REPROACH OUR SAVIOR FATHER IS FICKLE AND RIDDLED WITH INSINCERE PROMISES. WHEN YOU SEEK REDEMPTION DO NOT SEEK IT IN MAN KIND FOR THEY SHALL NOT ANSWER YOUR SONG. WHY DO YOU THINK YOU, AMONG ALL OF HIS CHILDREN, ARE SPECIAL? GAZE NOT UPON YOUR VISCERAL MEATY FORM AND INSTEAD REJOICE FOR WHAT MAY BECOME OF YOURSELF AS AN ENTITY. THE HUMAN BODY IS FRAIL AND WEAK AND LIGHT IS TO BECOME.";
    [SerializeField]private TextMeshPro textBody;
    private int currentLetterIndex = 0;
    void Awake()
    {
        screenBrighten.SetActive(true);
        textBody.gameObject.SetActive(true);
    }

    void Update()
    {
        if (currentLetterIndex < annoyingAssTextScroll.Length)
        {
            textBody.text += annoyingAssTextScroll[currentLetterIndex];
            currentLetterIndex++;
        }
        else
            CompleteEffect();
    }

    public override void CompleteEffect()
    {
        Destroy(gameObject);

    }
}
