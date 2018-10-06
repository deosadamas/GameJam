using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarManager : MonoBehaviour {

    public Slider timerBar;
    public Image background;
    public Image fill;

    bool isDangerous;

    public float CurrentTime;
    public float MaxTime;

	// Use this for initialization
	void Start ()
    {
        isDangerous = false;
        CurrentTime = 0;
        timerBar.maxValue = MaxTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isDangerous == false)
        {
            CurrentTime += Time.deltaTime;
        }
        else if (isDangerous == true)
        {
            CurrentTime -= Time.deltaTime;
        }

        if (CurrentTime >= 10 & isDangerous == false)
        {
            isDangerous = true;
            fill.color = new Color(255, 0, 0);
        }
        else if (CurrentTime <= 0 & isDangerous == true)
        {
            isDangerous = false;
            fill.color = new Color(0, 255, 0);

        }

        timerBar.value = CurrentTime;
        
    }
}
