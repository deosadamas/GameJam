using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private IEnumerator coroutine;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(DisableLaser());  
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DisableLaser()
    {
        yield return new WaitForSeconds(2);
        GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
        StartCoroutine(DisableLaser());
    }


}
