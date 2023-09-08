using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;

public class UiFunctions : MonoBehaviour
{

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
}
