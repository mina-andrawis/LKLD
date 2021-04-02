using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    
    public void PlayGame()
    {
        mainMenuUI.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
