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
    [Header("shoot info")]
    [SerializeField] private GameObject bulletPrefab;
    private bool canSprint = true;
    private bool canDash = true;
   
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

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.F) && canSprint){
            StartCoroutine("Sprint");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Dash();
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

    void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    IEnumerator Sprint()
    {
        canSprint = false;
        float initialSpeed = speed;
        speed += speed * 2;
        yield return new WaitForSeconds(3);
        speed = initialSpeed;
        canSprint = true;
    }


    void Dash()
    {
        
        transform.Translate(Vector3.forward * 8);
        
       
    }
}
