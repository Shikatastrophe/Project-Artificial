using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

interface EEvent
{
    public void Evento();
}

public class EventoBot : MonoBehaviour, IInteractable
{

    public GameObject ObjEvento;

    public void Interact()
    {
        if(ObjEvento.TryGetComponent(out EEvent ev))
        {
            ev.Evento();
        }
    }

}
