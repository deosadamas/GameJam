using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Destruction());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
