using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemove : MonoBehaviour, IInteractable
{
    public Transform ply;
    public Transform objecttoa;
    public GameObject ply2;

    public bool isHolding=false;

    public void Interact()
    {
        if (!isHolding)
        {
            isHolding = true;
            Debug.Log("loagarro");
            return;
        }
        if (isHolding)
        {
            isHolding = false;
            Debug.Log("lodejo");
            return;
        }
        
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (isHolding)
        {
            objecttoa.SetParent(ply);
            ply2.GetComponent<New2DMovement>().holdingBox = true;
        }
        if (!isHolding)
        {
            objecttoa.SetParent(null);
            ply2.GetComponent<New2DMovement>().holdingBox = false;
        }
          
    }
}
