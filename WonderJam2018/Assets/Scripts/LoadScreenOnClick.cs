using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenOnClick : MonoBehaviour {


    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }


    void setButtonActive()
    {
        GameObject go = GameObject.Find("BackButton");
        go.SetActive(GameObject.Find("BackButton"));
    }
}
