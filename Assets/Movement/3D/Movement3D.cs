using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Movement3D : MonoBehaviour
{ 
    public Rigidbody rb;

    public Transform cam;

    public float horizontal;
    public float vertical;

    public float initialspeed;
    float speed;
    public float scalingspeed;

    public Transform interactorSource;
    public float interactRange;

    public float smoothtime = 0.1f;
    float turnSmoothVelocity;

    private Vector3 previousPosition; //the previous position of the gameobject
    private Vector3 velocity; //the velocity vector of the gameobject
    private Vector3 yAxis; //the y axis vector

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position; //initialize the previous position
        yAxis = new Vector3(0, 1, 0); //initialize the y axis vector
        speed = initialspeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = transform.position - previousPosition; //calculate the velocity vector
        previousPosition = transform.position; //update the previous position

        float dot = Vector3.Dot(velocity, yAxis); //calculate the dot product

        if (dot > 0.01f)
        {
            Debug.Log("Moving upwards"); //log the movement direction
            speed = scalingspeed;

        }
        else if (dot == 0)
        {
            Debug.Log("Non"); //log the movement direction
            speed = initialspeed;

        }

        Vector3 direction = new Vector3(horizontal * speed, rb.velocity.y*0,vertical*speed);
        if (direction.magnitude >= 0.1f)
        {
            float targetangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnSmoothVelocity, smoothtime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 movedir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward;
            rb.velocity = movedir.normalized * speed;
            rb.velocity = new Vector3(rb.velocity.x, -1.2f, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(0,rb.velocity.y,0);
        }


    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        vertical = context.ReadValue<Vector2>().y;
    }

    

}
