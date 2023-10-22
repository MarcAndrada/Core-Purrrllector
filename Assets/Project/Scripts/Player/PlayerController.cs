using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum State { IDLE, MOVING, MINING};

    private Rigidbody2D rb;

    private float horizontalInput;
    private float verticalInput;

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
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Rotation();
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(horizontalInput * movementScale * Time.deltaTime, verticalInput * movementScale * Time.deltaTime), ForceMode2D.Force);
    }

    void Rotation()
    {
        if(rb.velocity != Vector2.zero) 
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, rb.velocity);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
