using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, IInteractable
{
    private bool gaming = true;
    public Animator animator;
    public void Interact()
    {
        if (gaming)
        {
            animator.Play("Second");
        }
        else
        {
            animator.Play("Main");
        }
        gaming = !gaming;
    }
}
