using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEditor;
using System.Collections;

public class Menu : MonoBehaviour
{
    [SerializeField] Animator[] _anim;
    public void Back()
    {
        /** Resetira sve animacije prilikom vraćanja u meni.*/
        foreach (var item in _anim)
        {
            item.enabled = true;
            item.Play("Reset");
        }
    }

    public void Event_QuitGame() => Application.Quit();

    public void StartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    public void LoadGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

}
