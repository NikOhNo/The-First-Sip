using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnClickStart()
    {
        // switch to main scene
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
