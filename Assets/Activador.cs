using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour
{
    //Este script se encarga de abrir una puerta cuando un GameObject en concreto entra en contacto con el trigger de  este objeto

    public GameObject puerta; //Objeto que se va a activar
    public GameObject objetoActivador; //Objeto que activa la puerta
    private Collider trigger; //Trigger que activa la puerta

    void Start()
    {
        //puerta.SetActive(false); //Desactivamos la puerta al inicio de la escena
        trigger = GetComponent<Collider>(); //Obtenemos el componente Collider del objeto
    }

    void OnTriggerEnter(Collider other) //Si el objeto activador entra en contacto con el trigger de este objeto
    {
        if (other.gameObject == objetoActivador) //Si el objeto que entra en contacto con el trigger es el objeto activador
        {
            puerta.transform.Rotate(0, 90, 0); //Rotamos la puerta 90 grados en el eje Y
            trigger.enabled = false; //Desactivamos el trigger para que no se vuelva a activar
            Debug.Log("Puerta activada");
        }
    }
}
