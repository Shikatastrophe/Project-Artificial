using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemove : MonoBehaviour, IInteractable
{
    public Transform ply;
    public Transform objecttoa;

    public void Interact()
    {
        objecttoa.SetParent(ply);
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
