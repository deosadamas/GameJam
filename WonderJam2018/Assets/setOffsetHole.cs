using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setOffsetHole : MonoBehaviour
{
    public float newFocus;
    public Camera cam;
   
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Player")
        {
            //cam.orthographicSize = newFocus;
            GetComponent<Collider2D>().enabled = false; 
        }


    }

  
}
