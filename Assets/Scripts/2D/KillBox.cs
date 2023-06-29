using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    public GameObject player;

    public Transform teleportsource;

    public Animator crossfadeanimator;

    public Animator dooranimator;
    // Start is called before the first frame update

    public void OnTriggerEnter2D()
    {
        dooranimator.SetTrigger("Crossfade");
        crossfadeanimator.SetTrigger("Crossfade");
    }

    public void Teleport()
    {
        player.transform.position = teleportsource.position;
    }
}
