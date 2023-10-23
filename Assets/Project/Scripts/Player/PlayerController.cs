using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum State { IDLE, MOVING, MINING};

    private Rigidbody2D rb;

    private Vector2 inputDirection;

    [SerializeField]
    private float movementScale;

    [SerializeField]
    private float rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.up * inputDirection.magnitude * movementScale, ForceMode2D.Force);
    }

    void Move()
    {
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.y = Input.GetAxisRaw("Vertical");
        inputDirection.Normalize();
    }

    void Rotation()
    {
        if(inputDirection != Vector2.zero) 
        {
            Quaternion toRotation = Quaternion.LookRotation(transform.forward, inputDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
