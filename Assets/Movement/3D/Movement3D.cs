using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement3D : MonoBehaviour
{ 
    public Rigidbody rb;
    
    public float horizontal;
    public float vertical;
    

    public float speed;
    public float previousYVelocity;


    public Transform interactorSource;
    public float interactRange;




    // Start is called before the first frame update
    void Start()
    {
        previousYVelocity = rb.velocity.y;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(horizontal * speed, rb.velocity.y,vertical*speed);

        float currentYVelocity = rb.velocity.y;

        
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;

    }

    

}
