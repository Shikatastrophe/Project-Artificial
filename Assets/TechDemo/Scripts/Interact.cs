using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Interact : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("A");
            Ray r = new Ray(interactorSource.position, interactorSource.right);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
