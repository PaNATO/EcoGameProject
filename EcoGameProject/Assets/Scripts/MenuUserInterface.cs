using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUserInterface : MonoBehaviour
{
    public Transform Menu;
    public static bool isGameRunning;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneNames.GamePlay);
        isGameRunning = true;
    }
    public void MenuGame()
    {
        SceneManager.LoadScene(SceneNames.Menu);
        isGameRunning = false;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
