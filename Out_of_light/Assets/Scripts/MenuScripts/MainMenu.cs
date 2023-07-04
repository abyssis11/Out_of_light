using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void EnterLevelMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(2);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying=false;
        Application.Quit();
    }
}
