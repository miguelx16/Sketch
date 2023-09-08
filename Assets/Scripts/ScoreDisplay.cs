using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    public int score = 0;
    ItemCollector inventory;
    public GameObject points;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = points.GetComponent<TextMeshProUGUI>();
       inventory = GetComponent<ItemCollector>();
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Puntos: {inventory.ballsCollected}";
    }
}
