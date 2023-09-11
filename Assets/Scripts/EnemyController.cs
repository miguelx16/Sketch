using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speedMove;
    private float speedRotate = 100;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Pablito").transform;
        speedMove = 6.3f;
    }


    private void LateUpdate()
    {
        transform.Translate(speedMove * Time.deltaTime * Vector3.forward);
        
        transform.Rotate(speedRotate * Time.deltaTime * Vector3.up);
        transform.LookAt(player);
    }

    public void HardOptions()
    {
        speedMove *= 1.2f;
    }
    
    public void EasyOptions()
    {
        speedMove = 6.3f;
    }
}
