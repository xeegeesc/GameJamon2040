using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MaquinaEstadosTortosa : MonoBehaviour
{

    private bool teHaEscuchado = false;
    public Transform jugador;
    //int MoveSpeed = 10;
    //int MaxDist = 2;
    private float MinDist = 1.5f;
    private Vector3 posicionJugadorEscuchado;
    private int vecesNoOido = 0;
    private NavMeshAgent navMeshAgent;
    private Animator animacion;
  

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animacion = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (teHaEscuchado)
        {
            
            transform.LookAt(posicionJugadorEscuchado);
            //Debug.Log(Vector3.Distance(transform.position, jugador.position));
            if (Vector3.Distance(transform.position, posicionJugadorEscuchado) >= 1.6)
            {
                    
                //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                
                navMeshAgent.SetDestination(posicionJugadorEscuchado);
                animacion.SetBool("estaCorriendo", true);
            }
        
        }
        if (Vector3.Distance(transform.position, jugador.position) <= MinDist)
        {
            Time.timeScale = 0;
            //ElJugadorMuere
            GameObject.Find("CanvasMuerte").GetComponent<Canvas>().enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


    public void TortosaTeHaEscuchado()
    {
            teHaEscuchado = true;
            vecesNoOido = 0;
            posicionJugadorEscuchado = jugador.position;
    }

    public void TortosaYaNoTeOye()
    {
        vecesNoOido += 1;
        if (Vector3.Distance(transform.position, posicionJugadorEscuchado) <= MinDist || vecesNoOido > 500)
        {
            if (teHaEscuchado == true)
            {
                teHaEscuchado = false;
                animacion.SetBool("estaCorriendo", false);
            }
        }
    }

}
