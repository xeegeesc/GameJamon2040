using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EstadoVictoria : MonoBehaviour
{

    public MaquinaEstadosXeva estadosXeva;
    public Transform jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Distancia a Victoria: " + Vector3.Distance(transform.position, jugador.position));
        
        if (Vector3.Distance(transform.position, jugador.position) <= 1.5)
        {
            if (estadosXeva.liberado)
            {
                //El jugador ha ganado!!
                Debug.Log("El jugador ha ganado!!");
                //SceneManager.LoadScene("Victoria");
            }
            else
            {
                //Mostrar Canvas/Texto para decirle al jugador el por qué no puede ganar aún.
                Debug.Log("Debes Salvar a Xeva para Salir de la casa!!");


            }
        }
    }



}
