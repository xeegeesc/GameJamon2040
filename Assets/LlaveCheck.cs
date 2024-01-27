using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveCheck : MonoBehaviour
{
    //Cuando el trigger entra en contacto con la llave la puerta se abre
    public GameObject llave;

    public GameObject player;

    private Collider trigger;

    public GameObject textoLlave;

    void Start()
    {
        trigger = GetComponent<Collider>(); //Obtenemos el componente Collider del objeto
    }


    void OnTriggerEnter(Collider other) //Si el objeto activador entra en contacto con el trigger de este objeto
    {
        if (other.gameObject == llave) //Si el objeto que entra en contacto con el trigger es el objeto activador
        {
            this.transform.Rotate(0, 90, 0); //Rotamos la puerta 90 grados en el eje Y
            trigger.enabled = false; //Desactivamos el trigger para que no se vuelva a activar
            Destroy(llave);
            Debug.Log("Puerta activada");
        }
        else if (other.gameObject == player)
        {
            textoLlave.SetActive(true);
            Debug.Log("No tienes la llave");
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            textoLlave.SetActive(false);
        }
    }


}
