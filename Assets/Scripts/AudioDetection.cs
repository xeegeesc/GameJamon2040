using UnityEngine;

public class AudioDetection : MonoBehaviour
{
    public float threshold = 0.1f; // Set the threshold value for detecting sound
    public float sensitivity = 100f; // Set the sensitivity value for detecting sound
    public float loudness = 0f; // The loudness of the sound detected
    public float updateInterval = 3f; // The interval at which to check for microphone input
    private bool micDetected = true; // Whether a microphone is currently detected
    private string deviceName; // The name of the microphone device
    private float timeSinceLastCheck = 0f; // The time since the last microphone check

    void Start()
    {
        if (Microphone.devices.Length == 0)
        {
            Debug.LogWarning("No se ha detectado ningún dispositivo de micrófono.");
            micDetected = false;
        }
        else
        {
            deviceName = Microphone.devices[0];
            GetComponent<AudioSource>().clip = Microphone.Start(deviceName, true, 10, 44100);
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().mute = true;
            while (!(Microphone.GetPosition(deviceName) > 0)) { }
            GetComponent<AudioSource>().Play();
        }
    }

    void Update()
    {
        timeSinceLastCheck += Time.deltaTime;
        if (timeSinceLastCheck >= updateInterval)
        {
            timeSinceLastCheck = 0f;
            if (Microphone.devices.Length == 0)
            {
                if (micDetected)
                {
                    Debug.LogWarning("El micrófono ya no está detectado.");
                    micDetected = false;
                }
            }
            else
            {
                if (!micDetected)
                {
                    Debug.Log("El micrófono ha sido detectado.");
                    micDetected = true;
                }
                loudness = GetAveragedVolume() * sensitivity;
                if (loudness > threshold)
                {
                    Debug.Log("¡El sonido ha superado el umbral de decibelios establecido!");
                    enabled = false;
                }
            }
        }
    }

    float GetAveragedVolume()
    {
        float[] data = new float[1024];
        float a = 0;
        GetComponent<AudioSource>().GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 1024;
    }
}
