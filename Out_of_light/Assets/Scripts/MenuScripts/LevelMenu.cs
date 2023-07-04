using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] public Button button1;
    [SerializeField] public Button button2;
    [SerializeField] public Button button3;
    [SerializeField] public Button button4;
    [SerializeField] public Button button5;
    void Start()
    {
        button2.interactable=false;
        button3.interactable=false;
        button4.interactable=false;
        button5.interactable=false;
    }
    public void startLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void startLevel2()
    {
        SceneManager.LoadScene(3);
    }
    public void startLevel3()
    {
        SceneManager.LoadScene(4);
    }
    public void startLevel4()
    {
        SceneManager.LoadScene(5);
    }
    public void startLevel5()
    {
        SceneManager.LoadScene(6);
    }
    public void goBack()
    {
        SceneManager.LoadScene(0);
    }
    
    public void UnlockButton(Button button)
    {
        button.interactable = true;
    }
}
