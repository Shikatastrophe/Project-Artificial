using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemove : MonoBehaviour, IInteractable
{
    public Transform ply;
    public Transform objecttoa;
    public GameObject ply2;
    public Rigidbody2D rb;

    public bool isHolding;

    public void Interact()
    {
        if (!isHolding)
        {
            isHolding = true;
            ply2.GetComponent<New2DMovement>().holdingBox = true;
            //Debug.Log("loagarro");
            return;
        }
        if (isHolding)
        {
            isHolding = false;
            ply2.GetComponent<New2DMovement>().holdingBox = false;
            //Debug.Log("lodejo");
            return;
        }
        
    }

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        if (isHolding)
        {
            objecttoa.SetParent(ply);
            
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        if (!isHolding)
        {
            objecttoa.SetParent(null);
            
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
          
    }
}
