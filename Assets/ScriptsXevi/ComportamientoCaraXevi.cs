using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoCaraXevi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GetComponentInParent<Transform>().position;
        transform.rotation = GetComponentInParent<Transform>().rotation;
    }
}
