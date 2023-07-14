using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoRandom3D : MonoBehaviour
{

    public float rotatespeed = 75f;
    public int x, y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Random.Range(1, 2);
        y = Random.Range(1, 2);
        if (x == 1)
        {
            transform.Rotate(Vector3.right * rotatespeed * Time.deltaTime, Space.World);
        }
        if (y == 1)
        {
            transform.Rotate(Vector3.up * rotatespeed * Time.deltaTime, Space.World);
        }
        if (x == 2)
        {
            transform.Rotate(Vector3.left * rotatespeed * Time.deltaTime, Space.World);
        }
        if (x == 2)
        {
            transform.Rotate(Vector3.down * rotatespeed * Time.deltaTime, Space.World);
        }
    }
}
