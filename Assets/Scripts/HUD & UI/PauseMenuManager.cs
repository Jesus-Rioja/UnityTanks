using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ResumeButtonClicked()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ActivatePause()
    {
        if(PauseMenu.activeInHierarchy)
        {
            Time.timeScale = 1.0f;
            PauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0.0f;
            PauseMenu.SetActive(true);
        }
    }

}
