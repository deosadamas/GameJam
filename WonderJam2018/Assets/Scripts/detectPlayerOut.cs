using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class detectPlayerOut : MonoBehaviour {

    public List<GameObject> players;
    public List<BoxCollider2D> playersColl;
    public Camera myCam;
    private Plane[] planes;

    public string winnerPlayer;
    public string outPlayer;
    public bool isPlayerOut = false;

    private void Start()
    {
        foreach(GameObject player in players)
        {
            playersColl.Add(player.GetComponent<BoxCollider2D>());
        }
    }

    private void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(myCam);

        int count = 0;
        foreach (BoxCollider2D playerColl in playersColl)
        {
            count++;
            if (!GeometryUtility.TestPlanesAABB(planes, playerColl.bounds))
            {
                outPlayer = "Player" + count;
                isPlayerOut = true;
            }
        }

        if (outPlayer == "Player1")
        {
            winnerPlayer = "Player2";
        }

        if (outPlayer == "Player2")
        {
            winnerPlayer = "Player1";
        }
        
        
    }


}
