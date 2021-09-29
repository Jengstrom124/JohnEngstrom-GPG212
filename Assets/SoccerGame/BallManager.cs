using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    Team ballteam;

    // Start is called before the first frame update
    void Start()
    {
        ballteam = this.GetComponent<Team>();
        //print(ballteam.myTeam);
    }

    // Update is called once per frame
    void Update()
    {
        ballteam.TeamColour();
    }

    //Change team of ball to the last player that touched it
    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Player")
        {
            ballteam.myTeam = c.gameObject.GetComponent<Team>().myTeam;
        }
    }

}
