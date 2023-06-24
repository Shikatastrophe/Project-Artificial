using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 1;

    public float PlayerSpeed = 5;
    Rigidbody rb;

    public 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float amtToMove = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
        float amtToMove2 = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * amtToMove);
        transform.Translate(Vector3.forward * amtToMove2);

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }
}
