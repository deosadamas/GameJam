using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImplementNamePlayer : MonoBehaviour {

    public Text boxText;
    private string resultName;

    // Use this for initialization
    void Start()
    {
        if (ApplicationModel.winner != null)
        {
            resultName = ApplicationModel.winner;
            boxText.text = resultName;
            Debug.Log(resultName);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
