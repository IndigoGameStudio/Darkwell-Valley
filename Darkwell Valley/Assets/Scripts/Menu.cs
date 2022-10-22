using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEditor;
using System.Collections;

public class Menu : MonoBehaviour
{
    public Animator[] _anim;
    public void Back()
    {
        foreach (var item in _anim)
        {
            item.enabled = true;
            item.Play("Reset");
        }
    }

    public void Event_QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
