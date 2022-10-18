using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEditor;

public class Menu : MonoBehaviour
{
    public GameObject go_Menu;
    public GameObject go_ExitCheck;
    public GameObject go_Settings;

    

    public void Event_NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Event_LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Event_Settings()
    {
        go_Settings.SetActive(true);
        go_Menu.SetActive(false);
    }

    public void Event_QuitGame()
    {
        go_Menu.SetActive(false);
        go_ExitCheck.SetActive(true);
    }

    public void Back()
    {
        go_Menu.SetActive(true);
        go_ExitCheck.SetActive(false);
        go_Settings.SetActive(false);
    }
}
