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
    public LayerMask interactable2D;
    public void InteractObj(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }

    public void InteractObj2D(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Collider2D[] interact = Physics2D.OverlapCircleAll(interactorSource.position, interactRange, interactable2D);

            foreach (Collider2D interactable in interact)
            {
                if (interactable.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}