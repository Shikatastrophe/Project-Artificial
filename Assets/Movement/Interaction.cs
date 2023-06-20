using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
}
public class Interaction : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange;

    public void InteractObj(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
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