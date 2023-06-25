using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class New2DMovement : MonoBehaviour
{


    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float horizontal;
    public float jumpingPower;

    private bool isFacingRight = true;


    public float speed;
    public float previousYVelocity;

    bool held = false;

    public PlayerInput playerInput;
 




    // Start is called before the first frame update
    void Start()
    {
        previousYVelocity = rb.velocity.y;
    }

    void Update()
    {
        if (DialogueManager.isActive)
        {
            playerInput.actions.FindAction("Move").Disable();
        }
        else
        {
            playerInput.actions.FindAction("Move").Enable();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
     
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);


        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }


        float currentYVelocity = rb.velocity.y;
    }

    public void Move(InputAction.CallbackContext context)
    {
       
        horizontal = context.ReadValue<Vector2>().x;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded())
        {
            if (context.performed)
            {
                held = true;
            }
            else if (context.canceled)
            {
                held = false;
            }
            if (held)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
        } 
        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

   
}
