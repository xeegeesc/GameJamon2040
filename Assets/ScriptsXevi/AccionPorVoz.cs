using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionPorVoz : MonoBehaviour
{
    //public AudioSource fuenteAudio;
    public MaquinaEstadosTortosa estadosTortosa;
    public DeteccionMicroPlayer deteccion;
    // Start is called before the first frame update

    public float sensibilidadVolumen = 100;
    public float umbralVolumen = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float volumen = deteccion.GetVolumenDeMicro() * sensibilidadVolumen;
        Debug.Log("Volumen detectado: " + volumen);


        if (volumen <= umbralVolumen)
        {
            volumen = 0;
        }
        else
        {
            estadosTortosa.TortosaTeHaEscuchado();
            Debug.Log("Tortosa te ha detectado!!!: " + volumen);

        }
    }
}
