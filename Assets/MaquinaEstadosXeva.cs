using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MaquinaEstadosXeva : MonoBehaviour
{
    public Transform jugador;
    public bool liberado = false;
    private Animator animacion;

    // Start is called before the first frame update
    void Start()
    {
        animacion = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Distancia entre PLAYER y XEVA!!!: " + Vector3.Distance(gameObject.transform.position, jugador.position));

        if (Vector3.Distance(gameObject.transform.position, jugador.position) <= 1.35f)
        {
            Liberado();
        }
        if (liberado)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(jugador.position);

            if (Vector3.Distance(gameObject.transform.position, jugador.position) >=3.06f)
            {
               animacion.SetBool("estaCorriendo", true);
            }
            else
            {
                animacion.SetBool("estaCorriendo", false);
            }
        }
    }

    
    public void Liberado()
    {
        if (liberado == false)
        {
            liberado = true;
            Debug.Log("Xeva Liberadoo!!!");
        }
    }


}
