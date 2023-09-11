using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class UiFunctions : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject pauseMenu;
    

    public void ChangeScene(string nameScene)

    {
        //Cargar Escena con un string
        SceneManager.LoadScene(nameScene);

    }
    public void CloseGame()

    {
        Application.Quit();

        //Esto quitarlo para el build
        if(UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.ExitPlaymode();
        }
    }

    public void ShowOptionsMenu()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void BackPauseMenu()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
