using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFollowScript : MonoBehaviour
{

    public Transform player = null;

    private float playerLoc;

    public GameObject colorMat;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Camera>().backgroundColor = colorMat.GetComponent<ColorMatScript>().GetColorRandom();
        playerLoc = player.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
         return;

        float updatePlayerLoc = player.position.y;

        if(updatePlayerLoc != playerLoc)
        {
            float NewCameraLoc = updatePlayerLoc - playerLoc;

            transform.position = new Vector3(transform.position.x , transform.position.y + NewCameraLoc, transform.position.z);
            playerLoc = updatePlayerLoc;
        }

        
    }
}
