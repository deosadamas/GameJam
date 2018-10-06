using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BehaviourManager : MonoBehaviour {

    public List<GameObject> obstacles;
    public Slider timerBar;
	
	// Update is called once per frame
	void SwitchBehaviour()
    {
        if(timerBar.value == 10 || timerBar.value == 0)
        {
            foreach(GameObject items in obstacles)
            {
                
            }
        }
    }

}
