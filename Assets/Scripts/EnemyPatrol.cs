using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float speed;
    UiFunctions globalFunctions;
    Vector3 zMov;
    // Start is called before the first frame update

    private void Start()
    {
        globalFunctions = FindAnyObjectByType<UiFunctions>();
        zMov = new Vector3(0, 0, 1);
    }

    void Update()
    {
        EnemyMovement(zMov);
    }

    private void OnCollisionEnter(Collision collision)
    {
        zMov = zMov * -1;
        if (collision.gameObject.name == "Pablito")
        {
            Debug.Log("Game Over");
            globalFunctions.ChangeScene("InitialMenu");
        }
    }

    void EnemyMovement(Vector3 zMov)
    {
        transform.Translate(zMov * speed * Time.deltaTime);
    }
}
