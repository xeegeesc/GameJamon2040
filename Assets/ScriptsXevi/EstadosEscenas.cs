using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class EstadosEscenas : MonoBehaviour
{

    public bool pausado = false;

    //private void Awake()
    //{
    //    if (SceneManager.GetActiveScene().name == "EscenarioSinPuertas_Vagabundo2")
    //    {
    //        Cursor.visible = false;
    //        Cursor.lockState = CursorLockMode.Locked;
    //    }
    //}
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name != "MenuPrincipal")
        {
            Time.timeScale = 1;
            GameObject.Find("CanvasPausa").GetComponent<Canvas>().enabled = false;
            GameObject.Find("CanvasMuerte").GetComponent<Canvas>().enabled = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("KeyCodeLeido: " + Keyboard.current.tabKey.wasPressedThisFrame);
        //KeyCode.Escape
        if (Keyboard.current.tabKey.wasPressedThisFrame && !pausado)
        {
            Time.timeScale = 0;
            GameObject.Find("CanvasPausa").GetComponent<Canvas>().enabled = true;
            pausado = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Keyboard.current.tabKey.wasPressedThisFrame && pausado)
        {
            Time.timeScale = 1;
            GameObject.Find("CanvasPausa").GetComponent<Canvas>().enabled = false;
            pausado = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

        }
    }

    public void reiniciarJuego()
    {
        SceneManager.LoadScene("EscenarioSinPuertas_Vagabundo2");
    }

    public void menuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void salirDelJuego()
    {
        Application.Quit();
    }

    public void DespausarJuego()
    {
        if (pausado)
        {
            Time.timeScale = 1;
            GameObject.Find("CanvasPausa").GetComponent<Canvas>().enabled = false;
            pausado = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


}
