using System.Collections;
using System.IO;
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
    private SaveObject saveObject;
    void Awake()
    {
        if (File.Exists(Application.dataPath + "/save.txt"))
        {
            saveObject = LoadData();
        }
        else
        {
            saveObject = new SaveObject();
        }
        button2.interactable= saveObject.level2;
        button3.interactable= saveObject.level3;
        button4.interactable= saveObject.level4;
        button5.interactable= saveObject.level5;
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

    private SaveObject LoadData()
    {
        string saveString = File.ReadAllText(Application.dataPath + "/save.txt");
        SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);
        return saveObject;
    }

}
