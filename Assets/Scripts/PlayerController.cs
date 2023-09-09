using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float gradesMultiply;
    float movX, movZ;
    [SerializeField] float speed;
    [SerializeField] Rigidbody rbPablito;
    Vector3 moveInput;
    Quaternion rotateInput;
    [SerializeField] private ItemCollector inventory;
   
    void Start()
    {
        rbPablito = GetComponent<Rigidbody>();
        //inventory = GetComponent<ItemCollector>();
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
        Vector3 directionToMove = rbPablito.rotation * moveInput;
        rotateInput = Quaternion.Euler(rotateInput.x, movX * gradesMultiply, rotateInput.z);

        rbPablito.MovePosition(rbPablito.position + directionToMove * speed * Time.fixedDeltaTime);
        rbPablito.MoveRotation(rbPablito.rotation * rotateInput);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            inventory.ballsCollected += 1;
            Destroy(gameObject);
        }
    }

}
