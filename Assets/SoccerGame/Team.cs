using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    public enum TeamNames
    {
        Red,
        Blue
    }

    public TeamNames myTeam;

   
    void Start()
    {
        TeamColour();
    }


    public void TeamColour()
    {
        if(this.GetComponent<Renderer>() != null)
        {
            if (myTeam == TeamNames.Red)
            {
                this.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                this.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
    }
    
}
