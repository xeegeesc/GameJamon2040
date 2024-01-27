using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionMicroPlayer : MonoBehaviour
{

    public int muestraVentana = 64;

    private AudioClip clipMicrofono;

    // Start is called before the first frame update
    void Start()
    {
        MicrofonoToAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MicrofonoToAudio()
    {
        string nombreMicrofono = Microphone.devices[0];
        Debug.Log("Nombre del microfono: " + nombreMicrofono);
        clipMicrofono = Microphone.Start(nombreMicrofono, true, 20, AudioSettings.outputSampleRate);
    }

    public  float GetVolumenDeMicro()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), clipMicrofono);
    }

    public float GetLoudnessFromAudioClip(int posicionClip, AudioClip clip)
    {
        int posicionInicio = posicionClip - muestraVentana;


        if (posicionInicio<0)
        {
            return 0;
        }
        float[] datosDeOnda = new float[muestraVentana];
        clip.GetData(datosDeOnda, posicionInicio);

        //calcular volumen

        float volumenTotal = 0;

        for(int i=0;i<muestraVentana; i++)
        {
            volumenTotal += Mathf.Abs(datosDeOnda[i]);
        }

        return volumenTotal / muestraVentana;
    }
}
