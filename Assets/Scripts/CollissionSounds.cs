using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollissionSounds : MonoBehaviour
{
    public AudioSource clashSound;
    // Start is called before the first frame update
    void Start()
    {
        clashSound=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            clashSound.Play();
        }
    }

}
