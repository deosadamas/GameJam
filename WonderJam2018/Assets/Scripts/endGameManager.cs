using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGameManager : MonoBehaviour {

    public GameObject cam;
    public string winner;

    // Use this for initialization
    void Start()
    {
    }

    private void LateUpdate()
    {
        if (cam.GetComponent<detectPlayerOut>().isPlayerOut == true)
        {
            winner = cam.GetComponent<detectPlayerOut>().winnerPlayer;
        }
        if (winner != "" || winner == null)
        {
            ApplicationModel.winner = winner;
            Debug.Log("Winner : "+winner);
            SceneManager.LoadScene("EndGameMenu");
        }
    }
}
