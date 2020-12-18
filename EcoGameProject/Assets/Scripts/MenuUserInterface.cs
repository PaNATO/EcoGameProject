using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuUserInterface : MonoBehaviour
{
    public Transform Menu;
    [SerializeField] Button LoadingGameButton;
    [SerializeField] Button ExitButton;
    //public static bool isGameRunning;
    public static bool isGameLoading = false;
    public static bool isNewGame = false;
    private string FilePath;
    public void NewGame()
    {
        isNewGame = true;
        SceneManager.LoadScene(SceneNames.GamePlay);
        //isGameRunning = true;
    }
    public void LoadGame()
    {
        isGameLoading = true;
        SceneManager.LoadScene(SceneNames.GamePlay);
    }
    public void MenuGame()
    {
        SceneManager.LoadScene(SceneNames.Menu);
        SaveLoadSystem.SaveLoadSystemInstance.SaveG();
        //isGameRunning = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    void Start()
    {
        FilePath = Path.Combine(Application.persistentDataPath, "Save.json");
        if (!File.Exists(FilePath))
        {
            LoadingGameButton.gameObject.SetActive(false);
            //Vector3 position = ExitButton.transform.position;
            //position.y += 40.74f;
            //ExitButton.transform.position = position;
        }
        else
        {
            LoadingGameButton.gameObject.SetActive(true);
        }
    }
}
