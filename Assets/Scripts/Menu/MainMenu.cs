using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Options");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
