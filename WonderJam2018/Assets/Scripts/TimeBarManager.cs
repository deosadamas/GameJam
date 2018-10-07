using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarManager : MonoBehaviour {

    public Slider timerBar;
    public Image background;
    public Image fill;
    public Image cadreRouge;

    public bool isDangerous;

    public float CurrentTime;
    public float MaxTime;
    private bool isActive;

	// Use this for initialization
	void Start ()
    {
        isDangerous = false;
        CurrentTime = 0;
        timerBar.maxValue = MaxTime;
        cadreRouge.enabled = false;
        isActive = false;
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
            if (isActive == false)
            {
                StartCoroutine(cadre());
                isActive = true;
            }
            fill.color = new Color(255, 0, 0);
        }
        else if (CurrentTime <= 0 & isDangerous == true)
        {
            isDangerous = false;
            fill.color = new Color(0, 255, 0);
            isActive = false;

        }

        timerBar.value = CurrentTime;

    }
    IEnumerator cadre()
    {

        cadreRouge.enabled = true;
        yield return new WaitForSeconds(1.5f);
        cadreRouge.enabled = false;

    }
}
