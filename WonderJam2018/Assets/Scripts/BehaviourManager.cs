using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BehaviourManager : MonoBehaviour {

    public List<Laser> laser;
    public List<Spring> spring;
    public List<Pounder> pounder;
    public List<Pateforme> plat;
    public List<Spike> spike;
    public List<SpikePlafond> spikePlafond;

    public Slider timerBar;
	
	// Update is called once per frame
	public void SwitchBehaviour()
    {
        if (timerBar.value == 10 || timerBar.value == 0)
        {
            foreach (Laser items in laser)
            {
                items.isDangerous = !items.isDangerous;
                Debug.Log(items.isDangerous);
            }

            foreach (Spring items in spring)
            {
                items.isDangerous = !items.isDangerous;
            }

            foreach (Pounder items in pounder)
            {
                items.isDangerous = !items.isDangerous;

            }

            foreach (Pateforme items in plat)
            {
                items.isDangerous = !items.isDangerous;
                Debug.Log("test" + items.isDangerous);
            }

            foreach (Spike items in spike)
            {
                items.isDangerous = !items.isDangerous;
            }

            foreach (SpikePlafond items in spikePlafond)
            {
                items.isDangerous = !items.isDangerous;
            }
        }
    }

}
