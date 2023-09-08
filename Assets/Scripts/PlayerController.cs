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
    [SerializeField]  private float speedMultiplier;
    [SerializeField] Rigidbody rbPablito;
    Vector3 moveInput;
    Quaternion rotateInput;

    [Header("Slide behavior")]
    [SerializeField] private float slideForce = 10f;
    [SerializeField] private float slideRotateSpeed = 30f;
    private bool isRunning = false;
    private bool isSliding = false;
    private bool isJumping = false;
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
        isRunning = Input.GetKey(KeyCode.LeftShift);
        isJumping = Input.GetKey(KeyCode.Space);

        if (!isSliding && Input.GetKeyDown(KeyCode.LeftControl))
        {
            isSliding = true;
            StartCoroutine(SlidingCoroutine());
        }
    }
    private void FixedUpdate()
    {

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") && !isSliding)
        {
            ControlMovement();
        }

    }
    void ControlMovement()
    {
        if (isRunning)
        {
            speedMultiplier = 2.25f;
        }
        else
        {
            speedMultiplier = 1f;
        }
        moveInput = new Vector3(movX, moveInput.y, movZ);
        Vector3 directionToMove = rbPablito.rotation * moveInput;
        rotateInput = Quaternion.Euler(rotateInput.x, movX * gradesMultiply, rotateInput.z);

        rbPablito.MovePosition(rbPablito.position + directionToMove * (speed * speedMultiplier)  * Time.fixedDeltaTime);
        rbPablito.MoveRotation(rbPablito.rotation * rotateInput);

    }

    private IEnumerator SlidingCoroutine()
    {
        isSliding = true;

        // Apply force to simulate sliding
        rbPablito.AddForce(transform.forward * slideForce, ForceMode.Impulse);

        // Calculate the target rotation
        Quaternion targetRotation = Quaternion.Euler(90f, transform.eulerAngles.y, transform.eulerAngles.z);

        float startTime = Time.time;
        float journeyLength = 1f; // Adjust this value to control the rotation speed

        while (Time.time < startTime + journeyLength)
        {
            float distanceCovered = (Time.time - startTime) / journeyLength;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, distanceCovered);
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure the final rotation is exactly 90 degrees.

        isSliding = false;
    }
}
