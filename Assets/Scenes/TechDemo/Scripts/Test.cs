using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, IInteractable
{
    private bool gaming = true;
    public Animator animator;
    public GameObject player2d, player3d;

    private void Start()
    {
        player2d.gameObject.SetActive(false);
        /*
        player2d.GetComponent<Movement2D>().enabled = false;
        player2d.GetComponent<SpriteRenderer>().enabled = false;
        */
    }
    public void Interact()
    {
        if (gaming)
        {
            animator.Play("Second");
            player2d.gameObject.SetActive(true);
            player3d.gameObject.SetActive(false);
            /*
            //player2d.GetComponent<Movement2D>().enabled = true;
            player2d.GetComponent<SpriteRenderer>().enabled = true;
            //player3d.GetComponent<Movement>().enabled = false;
            player3d.GetComponent<MeshRenderer>().enabled = false;
            */
        }
        else
        {
            animator.Play("Main");
            player2d.gameObject.SetActive(false);
            player3d.gameObject.SetActive(true);
            /*
            player2d.GetComponent<Movement2D>().enabled = false;
            player2d.GetComponent<SpriteRenderer>().enabled = false;
            player3d.GetComponent<Movement>().enabled = true;
            player3d.GetComponent<MeshRenderer>().enabled = true;
            */
        }
        gaming = !gaming;
    }
}
