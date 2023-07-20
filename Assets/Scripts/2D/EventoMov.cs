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
    bool activado = false;

    public void Evento()
    { 

            activado = true;
          
    }

    public void Mover()
    {

        Obj.transform.position = Vector3.MoveTowards(Obj.transform.position, new Vector3(Obj.transform.position.x+toX, Obj.transform.position.y + toY, Obj.transform.position.z + toZ), speed * Time.deltaTime);
    }

    public void FixedUpdate()
    {

        if (activado == true)
        {
            Mover();
            TiempoMoviendo = TiempoMoviendo - Time.deltaTime;
        }
        
        if(TiempoMoviendo < 0)
        {
            activado = false;
        }
    }
}
