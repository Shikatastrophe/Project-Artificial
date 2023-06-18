using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float PlayerSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float amtToMove = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * amtToMove);

        if (Input.GetKeyDown("space"))
        {
            transform.Translate(Vector3.up * PlayerSpeed);
        }
    }
}
