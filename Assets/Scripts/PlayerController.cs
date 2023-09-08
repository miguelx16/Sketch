using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform pablitoTransform;
    Transform objectiveToScale;
    [SerializeField] float gradesMultiply;
    float movX, movZ;
    [SerializeField] float speed;
    [SerializeField] Rigidbody rbPablito;
    Vector3 moveInput;
    Quaternion rotateInput;

    [SerializeField] GameObject lintern;
    [SerializeField] bool linternOn = true;
   
    void Start()
    {
        pablitoTransform = GetComponent<Transform>();
        rbPablito = GetComponent<Rigidbody>();
        InvokeRepeating("Lights", 10.0f, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");
        if(Input.GetKeyDown(KeyCode.F))
        {
            Lights();
        }

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
        Vector3 directionToMove = rbPablito.rotation * moveInput;
        rotateInput = Quaternion.Euler(rotateInput.x, movX * gradesMultiply, rotateInput.z);

        rbPablito.MovePosition(rbPablito.position + directionToMove * speed * Time.fixedDeltaTime);
        rbPablito.MoveRotation(rbPablito.rotation * rotateInput);

    }
    void Lights()
    {
        linternOn = !linternOn;
        lintern.SetActive(linternOn);
    }
}
