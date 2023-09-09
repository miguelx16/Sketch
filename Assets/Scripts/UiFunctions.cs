using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using Unity.VisualScripting;

public class UiFunctions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] ItemCollector points;

    private void Start()
    {
        points.ballsCollected = 0;
    }

    private void FixedUpdate()
    {
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        pointsText.text = "POINTS: " + points.ballsCollected.ToString();
    }


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
