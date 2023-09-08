using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinInteractive : MonoBehaviour
{
    CoinBag coinBag;
    public AudioSource coinGet;
    public AudioClip coinClip;

    void Start()
    {
        coinBag = GameObject.FindGameObjectWithTag("Player").GetComponent<CoinBag>();
        coinGet = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            coinBag.cantidad++;
            coinGet.PlayOneShot(coinClip);
            other.gameObject.SetActive(false);
        }
    }

    private void DestroyCoin()
    {
        gameObject.SetActive(false);
    }


}
