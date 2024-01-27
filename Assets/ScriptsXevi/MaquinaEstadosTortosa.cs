using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaEstadosTortosa : MonoBehaviour
{

    private bool teHaEscuchado = false;
    public Transform jugador;
    int MoveSpeed = 5;
    int MaxDist = 2;
    int MinDist = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (teHaEscuchado)
        {

            transform.LookAt(jugador);

            if (Vector3.Distance(transform.position, jugador.position) >= MinDist)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;

                if (Vector3.Distance(transform.position, jugador.position) <= MaxDist)
                {
                    if(Vector3.Distance(transform.position, jugador.position) <= MinDist)
                    {
                        Debug.Log("El jugador Muere!!!");
                        //ElJugadorMuere

                    }
                }

            }
            else
            {

                teHaEscuchado = false;
            }
        }
    }


    public void TortosaTeHaEscuchado()
    {
        if (teHaEscuchado == false)
        {
            teHaEscuchado = true;
        }
    }
}
