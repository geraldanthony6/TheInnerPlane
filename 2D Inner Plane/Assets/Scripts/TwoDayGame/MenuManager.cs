using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("RockGame");
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
