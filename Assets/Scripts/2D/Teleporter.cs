using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour, IInteractable
{
    public GameObject player;

    public Transform teleportsource;

    public Animator crossfadeanimator;

    public Animator dooranimator;

    public Animator cameraAnimator;

    public string cameraToChangeTo;

    
    // Start is called before the first frame update

    public void Interact()
    {
        dooranimator.SetTrigger("Crossfade");
        crossfadeanimator.SetTrigger("Crossfade");
    }

    public void Teleport()
    {
        player.transform.position = teleportsource.position;
    }

    public void SwitchCamera()
    {
        cameraAnimator.Play(cameraToChangeTo);
    }
}
