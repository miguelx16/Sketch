using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
}
