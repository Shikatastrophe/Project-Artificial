using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoMov : MonoBehaviour, EEvent
{
    public GameObject Obj;
    public float toX;
    public float toY;
    public float toZ;
    public float speed;
    public float TiempoMoviendo;
    bool activado=false;

   public void Evento()
    {
        if (TiempoMoviendo > Time.deltaTime)
        {
            activado = true;
        }
        else
        {
            activado = false;
        }
    }

    public void Mover()
    {

        Obj.transform.position = Vector3.MoveTowards(Obj.transform.position, new Vector3(toX, toY, toZ), speed * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        if (activado)
        {
            Mover();
        }
    }
}
