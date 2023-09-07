using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicloDeVida : MonoBehaviour
{
    [SerializeField] Transform pablitoTransform;
    Transform objectiveToScale;
    public float movX, movZ;
    public float speed;
    [SerializeField] Rigidbody rbPablito;
    Vector3 moveInput;
    public string tag;

    //Data to be saved in gameplay
    Vector3 originalScale;
    Vector3 scaledFactor;
    int chanceToLife = 0;
    void Start()
    {
        pablitoTransform = GetComponent<Transform>();
        rbPablito = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            ControlMovement();
        } 

    }
    void ControlMovement()
    {
        moveInput = new Vector3(movX, moveInput.y, movZ);

        rbPablito.MovePosition(rbPablito.position + moveInput.normalized * speed * Time.fixedDeltaTime);

    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Mushroom"))
        {
            /*general = LayerMask.NameToLayer("Default");
            this.gameObject.layer = general;

            originalScale = objectiveToScale.localScale;

            scaledFactor = new Vector3(originalScale.x * 2, originalScale.y * 2, originalScale.z * 2);

            ChangeScale(objectiveToScale,scaledFactor);
            chanceToLife = 1;


        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            switch (chanceToLife)
            {
                case 0:
                    //se muere;
                    break;

                case 1:
                    ChangeScale(objectiveToScale, originalScale);
                    chanceToLife = 0;
                    break;
            }

            
        }

    }*/

    void ChangeScale(Transform toChangeScale, Vector3 newScale)

    {
        toChangeScale.localScale = new Vector3(newScale.x, newScale.y, newScale.z);
    }
    

}
