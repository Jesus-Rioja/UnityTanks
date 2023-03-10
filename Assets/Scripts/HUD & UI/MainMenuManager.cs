using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class GamemodeSelector
{
    public static int Gamemode = 0;
}

public class MainMenuManager : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void SelectGamemode(int gamemode)
    {
        GamemodeSelector.Gamemode = gamemode;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
