using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float dashSpeed;
    public float dashCoolDown;
    public float elapsedTime;


    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Move
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        if (elapsedTime > 0f)
        {
            elapsedTime -= Time.deltaTime;
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.Space) && elapsedTime <= 0f)
        {
            if (moveInput == Vector2.left)
            {
                rb.AddForce(Vector2.left * dashSpeed);
            } else
            {
                rb.AddForce(Vector2.right * dashSpeed);
            }
            elapsedTime = 1f;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}

     
        
    
